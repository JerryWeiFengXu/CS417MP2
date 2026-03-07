using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class countDown : MonoBehaviour
{
    public Text timeText;

    public Text loveText;
    float time = 0;
    public float cooldown = 2f;
    public Button myButton;
    public float money = 0;
    public float moneyF = 0;

    public float love = 0;
    public float loveF = 0;

    public float rate = 3;

    public float rateLove = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (timeText == null)
        {
            timeText = GetComponent<Text>();
        }
    }

    public void addScore(float amount) {
        if (!myButton.interactable) return;
        money += amount;
        moneyF = Mathf.Floor(money);
        timeText.text = moneyF.ToString();
        updateUI();

        StartCoroutine(ButtonCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        money = money + Time.deltaTime * rate;
        moneyF = Mathf.Floor(money);

        love = love + Time.deltaTime * rate / 3;
        loveF = Mathf.Floor(love);
       
        timeText.text = moneyF.ToString();

        loveText.text = loveF.ToString();
    }
    void updateUI() {
        Debug.Log("increment");
        timeText.text = moneyF.ToString();
        loveText.text = loveF.ToString();
    }

    IEnumerator ButtonCooldown()
    {
        myButton.interactable = false;
        yield return new WaitForSeconds(cooldown);
        myButton.interactable = true;
    }

}
