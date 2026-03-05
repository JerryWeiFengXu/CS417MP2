using UnityEngine;
using UnityEngine.XR;

public class Generator : MonoBehaviour
{
    public GameObject generatorPrefab;   
    public Transform spawnPoint;         
    public float cost = 20f;
    public float rateIncrease = 2f;
    private countDown resourceSystem;
    private bool wasPressedLastFrame = false;

    void Start()
    {
        resourceSystem = FindObjectOfType<countDown>();
    }

    void Update()
    {
        CheckButtonPress();
    }

    void CheckButtonPress()
    {
        InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed))
        {
            if (pressed && !wasPressedLastFrame)
            {
                PlantGenerator();
            }
            wasPressedLastFrame = pressed;
        }
    }

    void PlantGenerator()
    {
        if (resourceSystem.money >= cost)
        {
            resourceSystem.money -= cost;
            resourceSystem.rate += rateIncrease;
            Instantiate(generatorPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}