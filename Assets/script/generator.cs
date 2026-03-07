using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneratorButton : MonoBehaviour
{
    public countDown resourceSystem;
    public Button generatorButton;
    public TMP_Text buttonLabel;

    public float cost = 100f;
    public float rateIncrease = 2f;

    void Start()
    {
        if (resourceSystem == null)
            resourceSystem = FindObjectOfType<countDown>();

        UpdateButtonVisual();
    }

    void Update()
    {
        UpdateButtonVisual();
    }

    public void BuyGenerator()
    {
        if (resourceSystem != null && resourceSystem.money >= cost)
        {
            resourceSystem.money -= cost;
            resourceSystem.rate += 2;
            resourceSystem.rateLove += 1;

            UpdateButtonVisual();
        }
    }

    void UpdateButtonVisual()
    {
        if (resourceSystem == null || generatorButton == null) return;

        if (resourceSystem.money >= cost)
        {
            generatorButton.image.color = Color.white;

            if (buttonLabel != null)
                buttonLabel.text = "GENERATOR";
        }
        else
        {
            generatorButton.image.color = Color.gray;

            if (buttonLabel != null)
                buttonLabel.text = "GENERATOR";
        }
    }
}