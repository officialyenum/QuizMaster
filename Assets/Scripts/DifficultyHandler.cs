using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyHandler : MonoBehaviour
{
    StartHandler startHandler;
    CategoryHandler categoryHandler;
    GameManager gameManager;
    void Awake()
    {
        startHandler = FindObjectOfType<StartHandler>();
        gameManager = FindObjectOfType<GameManager>();
        categoryHandler = FindObjectOfType<CategoryHandler>();
    }

    public void ShowSelectCategory()
    {
        categoryHandler.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ShowSelectStart()
    {

        startHandler.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SetDifficulty(string value)
    {

        gameManager.difficulty = value;
        ShowSelectCategory();
    }

    public string GetDifficulty()
    {
        return gameManager.difficulty;
    }
}
