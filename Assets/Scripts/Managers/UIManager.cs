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
    [SerializeField]
    private TMP_Text _livesText;
    [SerializeField]
    private GameObject _gameOverText;
    [SerializeField]
    private GameObject _elevatorPanelGO;
    [SerializeField]
    private TMP_Text _elevatorPanelInstructions;
    [SerializeField]
    private string _meetsRequirementText, _doesNotMeetRequirementsText;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        if (_coinText == null)
            Debug.LogError("The UI Manager does not have a coin text.");
        if (_livesText == null)
            Debug.LogError("The UI Manager does not have a lives text.");
    }

    public void UpdateCoinText(int amount)
    {
        _coinText.text = $"Coins: {amount}";
    }

    public void UpdateLivesText(int amount)
    {
        _livesText.text = $"Lives: {amount}";
    }

    public void GameOverText()
    {
        _gameOverText.SetActive(true);
    }

    public void ElevatorPanelText(bool canInteract, bool setActive)
    {
        _elevatorPanelGO.SetActive(setActive);
        if (canInteract)
            _elevatorPanelInstructions.text = _meetsRequirementText;
        if (!canInteract)
            _elevatorPanelInstructions.text = _doesNotMeetRequirementsText;
    }
}
