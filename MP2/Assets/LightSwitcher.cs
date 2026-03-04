using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitcher : MonoBehaviour
{
    public Light light;
    public InputActionReference action;

    void Start() {
        light = GetComponent<Light>();

        action.action.Enable();
        action.action.performed += ctx => 
        {
            if (ctx.performed) ChangeColor();
        };
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ChangeColor();
        }
    }

    void ChangeColor() {
        if (light.color == Color.white)
            light.color = new Color(131f/255f, 22f/255f, 145f/255f);
        else
            light.color = Color.white;
    }
}