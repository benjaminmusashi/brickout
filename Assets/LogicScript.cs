using TMPro;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;
    public TextMeshProUGUI high;
    private float currentTime = 0;
    private int currentScore = 0;
    private int highScore = 0;
    private string highScoreKey = "HighScore";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        high.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        time.text = ((int)currentTime).ToString();
        score.text = currentScore.ToString();
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(highScoreKey, highScore);
            high.text = highScore.ToString();
        }
    }

    public void addScore()
    {
        currentScore += 100;
    }
}
