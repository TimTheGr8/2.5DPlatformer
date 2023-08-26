using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private Renderer _callButton;
    [SerializeField]
    private Material _callButtonMat;

    private bool _canInteract = false;

    private void OnTriggerStay(Collider other)
    {
        Player player;
        if(other.tag == "Player")
        {
            _canInteract = true;
            player = other.GetComponent<Player>();
            UIManager.Instance.ElevatorPanelText(_canInteract);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _canInteract = false;
            UIManager.Instance.ElevatorPanelText(_canInteract);
        }
    }

    public void CallElevator()
    {
        if (_canInteract)
        {
            _callButton.material = _callButtonMat;
            //_callButton.material.color = Color.green;
        }
    }
}
