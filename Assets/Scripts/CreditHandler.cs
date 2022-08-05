using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditHandler : MonoBehaviour
{
    StartHandler startHandler;
    GameManager gameManager;
    void Awake()
    {
        startHandler = FindObjectOfType<StartHandler>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ShowSelectStart()
    {
        startHandler.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
