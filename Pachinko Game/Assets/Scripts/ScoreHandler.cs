using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    // will fetch this info from here to display it elsewhere   
    [SerializeField]
    public TMP_Text scoreText;
    private int score = 0;

    public void AddPoint()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
