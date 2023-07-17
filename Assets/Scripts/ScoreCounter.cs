using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text Score;

    void Update()
    {
        Score.text = "Score: " + MageManager.total_score;
    }
}