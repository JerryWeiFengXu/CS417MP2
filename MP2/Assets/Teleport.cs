using UnityEngine;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{
    public Transform roomLocation;
    public Transform externalLocation;
    
    private bool hasTeleported = false;

    public InputActionReference action;

    public void Start()
    {
        action.action.Enable();
        action.action.performed += ctx => {
            if (ctx.performed) ChangeLocation();
        };
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ChangeLocation();
        }
    }

    public void ChangeLocation()
    {
        if (!hasTeleported)
        {
            transform.position = externalLocation.position;
            transform.rotation = externalLocation.rotation;
            hasTeleported = true;
        }
    }
}