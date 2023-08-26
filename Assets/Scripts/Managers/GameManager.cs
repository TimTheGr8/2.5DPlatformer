using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("The Game Manager is NULL.");

            return _instance;
        }
    }

    private bool _isGameOver = false;

    private void Awake()
    {
        _instance = this;
    }

    public bool IsGameOver()
    {
        return _isGameOver;
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
