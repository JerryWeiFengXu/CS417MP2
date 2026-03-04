using UnityEngine;
using UnityEngine.InputSystem; 

public class LightSwitcher : MonoBehaviour
{
    public Light myLight;

    void Start()
    {
        if (myLight == null)
            myLight = GetComponent<Light>();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.mKey.wasPressedThisFrame)
        {
            myLight.color = Color.blue; 
        }
    }
}