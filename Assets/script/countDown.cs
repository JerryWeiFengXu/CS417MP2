using UnityEngine;
using UnityEngine.UI;

public class countDown : MonoBehaviour
{
    public Text timeText;
    float time = 0;
    public float money = 0;
    public float moneyF = 0;
    public float rate = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (timeText == null)
        {
            timeText = GetComponent<Text>();
        }
    }

    public void addScore(float amount) {
        money += amount;
        moneyF = Mathf.Floor(money);
        timeText.text = moneyF.ToString();
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
        money = money + Time.deltaTime * rate;
        moneyF = Mathf.Floor(money);
       
        timeText.text = moneyF.ToString();
    }
    void updateUI() {
        Debug.Log("increment");
        timeText.text = moneyF.ToString();
    }

}
