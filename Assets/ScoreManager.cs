using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text tmpScore;
    public int score;

    void Awake()
    {
        instance = this;
        score = 0;
    }

    void Start()
    {
        UpdateScore(0);
    }

    public void SaveHighScore()
    {
        var high = PlayerPrefs.GetInt("highScore");
        if (score > high)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        SaveHighScore();
        tmpScore.text = "Score :" + this.score;
    }
}