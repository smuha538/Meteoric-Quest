using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public TMP_Text scoreText;
    void Start()
    {
        UpdateScoreText();
    }

    public void IncrementScore(int amount)
    {
        score = score + amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); 
        }
        else
        {
            Debug.LogWarning("TextMesh component not assigned to ScoreManager.");
        }
    }
}
