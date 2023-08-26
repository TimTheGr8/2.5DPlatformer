using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private ElevatorPanel _elevatorPanel;

    private PlayerInputs _inputs;

    // Start is called before the first frame update
    void Start()
    {
        _inputs = new PlayerInputs();
        _inputs.Player.Enable();
        _inputs.Player.Move.performed += Move_performed;
        _inputs.Player.Move.canceled += Move_canceled;
        _inputs.Player.Jump.performed += Jump_performed;
        _inputs.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(InputAction.CallbackContext context)
    {
        _elevatorPanel.CallElevator();
    }

    private void Jump_performed(InputAction.CallbackContext context)
    {
        _player.Jump();
    }

    private void Move_canceled(InputAction.CallbackContext context)
    {
        _player.SetWalk(0);
    }

    private void Move_performed(InputAction.CallbackContext context)
    {
        _player.SetWalk(context.ReadValue<float>());
    }
}
