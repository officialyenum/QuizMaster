using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class StartHandler : MonoBehaviour
{
    DifficultyHandler difficultyHandler;
    CreditHandler creditHandler;
    
    void Awake()
    {
        difficultyHandler = FindObjectOfType<DifficultyHandler>();
        creditHandler = FindObjectOfType<CreditHandler>();
    }

    public void ShowSelectDifficulty()
    {
        difficultyHandler.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ShowCredit()
    {
        creditHandler.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

}
