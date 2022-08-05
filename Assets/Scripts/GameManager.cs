using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    StartHandler startHandler;
    DifficultyHandler difficultyHandler;
    CategoryHandler categoryHandler;
    CreditHandler creditHandler;
    EndScreen endScreen;
    public string difficulty = "easy";
    public int category = 9;
    public string categoryName = "General Knowlwedge";
    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        startHandler = FindObjectOfType<StartHandler>();
        difficultyHandler = FindObjectOfType<DifficultyHandler>();
        categoryHandler = FindObjectOfType<CategoryHandler>();
        creditHandler = FindObjectOfType<CreditHandler>();
        endScreen = FindObjectOfType<EndScreen>();
    }

    void Start()
    {
        startHandler.gameObject.SetActive(true);
        quiz.gameObject.SetActive(false);
        difficultyHandler.gameObject.SetActive(false);
        categoryHandler.gameObject.SetActive(false);
        creditHandler.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if (quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.ShowFinalScore();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
