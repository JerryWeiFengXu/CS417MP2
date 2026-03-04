using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class losingScreen : MonoBehaviour
{
    public Transform PlayerTransform;
    public Text losingText;
    public Vector3 externalPosition = new Vector3(-20, 0, 0);
    float time = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        PlayerTransform = player.transform;
        losingText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    { 
        time -= Time.deltaTime;
        if (time <= 0)
        {
            PlayerTransform.position = externalPosition;
            losingText.text = "You lost";
        } 
    }
}
