using UnityEngine;

public class ButtonExample : MonoBehaviour
{
    public countDown score;         
    public float incrementAmount = 1f;

    public void ManualIncrement()
    {
        if (score != null)
        {
            score.addScore(incrementAmount);  
         
        }
    }
}