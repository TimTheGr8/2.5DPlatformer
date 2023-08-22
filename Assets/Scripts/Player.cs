using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.5f;

    private CharacterController _controller;
    private Vector3 _direction;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (_controller == null)
            Debug.LogError("The Player does not have a Character Controller component.");
    }

    void Update()
    {
        if(Keyboard.current.aKey.wasPressedThisFrame)
        {
            _direction.x = -1;
            // Move Left
        }
        if(Keyboard.current.dKey.wasPressedThisFrame)
        {
            _direction.x = 1;
            // Move Right
        }

        _controller.Move(_direction * Time.deltaTime * _speed);
    }
}
