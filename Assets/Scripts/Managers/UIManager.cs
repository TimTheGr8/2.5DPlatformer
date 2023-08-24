using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
             if(_instance == null)
                Debug.LogError("UI Manager is NULL");

            return _instance;
        }
    }

    [SerializeField]
    private TMP_Text _coinText;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        if (_coinText == null)
            Debug.LogError("The UI Manager does not have a coin text.");
    }

    public void UpdateCoinText(int amount)
    {
        _coinText.text = $"Coins: {amount}";
    }
}
