using UnityEngine;

public class ScoreTriggerHardcoded : MonoBehaviour
{
    public countDown scoreSystem; // reference to your countDown script
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    private bool object1Shown = false;
    private bool object2Shown = false;
    private bool object3Shown = false;

    public float score1 = 100;
    public float score2 = 200;
    public float score3 = 300;

    void Start()
    {
        // hide all objects at start
        if (object1 != null) object1.SetActive(false);
        if (object2 != null) object2.SetActive(false);
        if (object3 != null) object3.SetActive(false);
    }

    void Update()
    {
        float currentScore = scoreSystem.moneyF;

        if (!object1Shown && currentScore >= 100 && scoreSystem.loveF > 20)
        {
            object1.SetActive(true);
            object1Shown = true;
            Debug.Log("Object 1 appeared!");
        }

        if (!object2Shown && currentScore >= 200 && scoreSystem.loveF > 40)
        {
            object2.SetActive(true);
            object2Shown = true;
            Debug.Log("Object 2 appeared!");
        }

        if (!object3Shown && currentScore >= 300 && scoreSystem.loveF > 60)
        {
            object3.SetActive(true);
            object3Shown = true;
            Debug.Log("Object 3 appeared!");
        }
    }
}