using UnityEngine;

public class Orbit : MonoBehaviour
{
    // Adjust this variable in the Inspector to change speed
    public float rotationSpeed = 50.0f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}