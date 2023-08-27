using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private Renderer _callButton;
    [SerializeField]
    private Material _elevatorCalledMaterial;
    [SerializeField]
    private Material _elevatorReturningMaterial;
    [SerializeField]
    private Elevator _elevatorToCall;
    [SerializeField]
    private int _coinsToCallElevator = 8;

    private bool _canInteract = false;
    private bool _elevatorCalled = false;

    private void Start()
    {
        if (_elevatorToCall == null)
            Debug.LogError("There is no Elevator hooked up.");
    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.tag == "Player")
        {
            Player player;
            player = other.GetComponent<Player>();
            if(player != null && player.CoinCount() >= _coinsToCallElevator)
                _canInteract = true;

            UIManager.Instance.ElevatorPanelText(_canInteract, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _canInteract = false;
            UIManager.Instance.ElevatorPanelText(_canInteract, false);
        }
    }

    public void CallElevator()
    {
        if (_canInteract)
        {
            _elevatorCalled = !_elevatorCalled;
            if (_elevatorCalled)
                _callButton.material = _elevatorCalledMaterial;
            else
                _callButton.material = _elevatorReturningMaterial;

            _elevatorToCall.MoveElevator();
        }
    }
}
