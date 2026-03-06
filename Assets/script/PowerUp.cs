using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Power : MonoBehaviour
{
    public countDown resourceSystem;
    public Button powerButton;
    public TMP_Text buttonLabel;

    public float unlockMoneyRequired = 200f;
    public float baseRate = 3f;
    public float generatorContribution = 2f;
    public float multiplier = 2f;

    private bool unlocked = false;
    private bool activated = false;

    void Start()
    {
        if (resourceSystem == null)
            resourceSystem = FindObjectOfType<countDown>();

        powerButton.image.color = Color.gray;
        buttonLabel.text = "LOCKED";
    }

    void Update()
    {
        int generatorCount = FindObjectsOfType<generatorTracker>().Length;
        float currentMultiplier = activated ? multiplier : 1f;

        resourceSystem.rate = baseRate + generatorCount * generatorContribution * currentMultiplier;

        if (!unlocked && resourceSystem.money >= unlockMoneyRequired)
        {
            unlocked = true;
            powerButton.image.color = Color.white;
            buttonLabel.text = "POWER UP";
        }
    }

    public void ActivatePowerUp()
    {
        if (!unlocked || activated) return;

        activated = true;
        buttonLabel.text = "POWER ACTIVE";
    }
}