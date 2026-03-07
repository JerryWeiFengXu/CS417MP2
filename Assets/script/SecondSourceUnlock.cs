using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecondSourceUnlock : MonoBehaviour
{
    public countDown resourceSystem;
    public Button unlockButton;
    public GameObject secondCube;
    public TMP_Text buttonLabel;

    public float unlockCost = 1000f;
    public float secondResource = 0f;
    public float secondRate = 1f;

    public float baseScale = 0.2f;
    public float scaleFactor = 0.02f;

    private bool unlocked = false;

    private Color lockedColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    private Color unlockedColor = Color.white;

    void Start()
    {
        if (resourceSystem == null)
        {
            resourceSystem = FindObjectOfType<countDown>();
            
        }

        if (secondCube != null)
        {
            secondCube.SetActive(false);
        }

        UpdateButtonState();
    }

    void Update()
    {
        if (!unlocked)
        {
            UpdateButtonState();
            return;
        }

        secondResource += Time.deltaTime * secondRate;
        UpdateCubeVisual();
    }

    public void BuySecondSource()
    {
        Debug.Log("BuySecondSource clicked");

        if (unlocked)
        {
            
            return;
        }

        if (resourceSystem == null)
        {
            
            return;
        }

        if (secondCube == null)
        {
            // Debug.Log("secondCube is NULL");
            return;
        }

        Debug.Log("Current money = " + resourceSystem.money);
        Debug.Log("Unlock cost = " + unlockCost);

        if (resourceSystem.money >= unlockCost)
        {
            resourceSystem.addScore(-unlockCost);

            unlocked = true;
            secondCube.SetActive(true);

            secondResource = 0f;
            UpdateCubeVisual();
            UpdateButtonState();

            // Debug.Log("Second source unlocked!");
        }
        else
        {
            // Debug.Log("Not enough money.");
        }
    }

    void UpdateCubeVisual()
    {
        if (secondCube == null) return;

        float size = baseScale + Mathf.Floor(secondResource) * scaleFactor;
        secondCube.transform.localScale = new Vector3(size, size, size);
    }

    void UpdateButtonState()
    {
        if (unlockButton == null) return;

        float currentMoney = (resourceSystem != null) ? resourceSystem.money : -1f;
        bool canAfford = resourceSystem != null && resourceSystem.money >= unlockCost;

        Debug.Log("Money = " + currentMoney + " | Cost = " + unlockCost + " | CanAfford = " + canAfford);

        if (unlocked)
        {
            unlockButton.interactable = false;

            if (unlockButton.image != null)
                unlockButton.image.color = unlockedColor;

            if (buttonLabel != null)
                buttonLabel.text = "Unlocked";

            return;
        }

        unlockButton.interactable = canAfford;

        if (unlockButton.image != null)
            unlockButton.image.color = canAfford ? unlockedColor : lockedColor;

        if (buttonLabel != null)
        {
            if (canAfford)
                buttonLabel.text = "Unlock Cube";
            else
                buttonLabel.text = "Need " + unlockCost.ToString("0") + " Coins";
        }
    }
}