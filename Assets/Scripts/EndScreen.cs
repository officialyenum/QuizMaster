using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI infoText;
    ScoreKeeper scoreKeeper;
    GameManager gameManager;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ShowFinalScore()
    {
        int score = scoreKeeper.CalculateScore();
        Debug.Log($"score > 90 : {score > 90}");
        Debug.Log($"score >= 50 && score < 90 : {score >= 50 && score < 90}");
        Debug.Log($"score < 50 : {score < 50}");
        if (score >= 90)
        {
            finalScoreText.text = "Woah that's bananas !!!.. alright be humble and go again \n Score :" + score + "%";
        }
        else if (score >= 65 && score < 90)
        {
            finalScoreText.text = "Nice but no slacking, lets hit it again. \n Score :" + scoreKeeper.CalculateScore() + "%";
        }
        else if (score > 50 && score < 65)
        {
            finalScoreText.text = "It's good but you can do better, don't give up. \n Score :" + scoreKeeper.CalculateScore() + "%";
        }
        else
        {
            finalScoreText.text = "Hey don't be moody and try again. \n Score :" + scoreKeeper.CalculateScore() + "%";
        }
        infoText.text = $"Difficulty : {gameManager.difficulty}\nCategory :{gameManager.categoryName} ";
    }
}
