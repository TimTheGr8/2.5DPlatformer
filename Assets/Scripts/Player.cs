using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.5f;
    [SerializeField]
    private float _jumpHeight = 15f;
    [SerializeField]
    private float _gravity = 1.0f;

    private CharacterController _controller;
    private Vector3 _direction;
    private float _yVelocity = 0;
    private bool _hasJumped = false;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (_controller == null)
            Debug.LogError("The Player does not have a Character Controller component.");
    }

    void Update()
    {
        CalculateMovement();
    }

    public void SetWalk(float walk)
    {
        _direction = new Vector3(walk, 0, 0);
    }

    public void Jump()
    {
        _hasJumped = true;
    }

    private void CalculateMovement()
    {
        var velocity = _direction * _speed;
        if (_controller.isGrounded)
        {
            if (_hasJumped)
            {
                _yVelocity = _jumpHeight;
                _hasJumped = false;
            }
        }
        else if (!_controller.isGrounded)
        {
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
