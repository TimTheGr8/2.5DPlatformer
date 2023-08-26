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
    [SerializeField]
    private int _maxLifeCount = 3;

    private CharacterController _controller;
    private Vector3 _direction;
    private float _walk = 0;
    private float _yVelocity = 0;
    private int _jumpCount = 0;
    private int _coinCount = 0;
    private int _lives;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (_controller == null)
            Debug.LogError("The Player does not have a Character Controller component.");

        _lives = _maxLifeCount;
        UIManager.Instance.UpdateLivesText(_lives);
    }

    void FixedUpdate()
    {
        if(!GameManager.Instance.IsGameOver())
            CalculateMovement();
    }

    public void SetWalk(float walk)
    {
        _walk = walk;
    }

    public void Jump()
    {
        if (_jumpCount < 2)
        {
            _jumpCount++;
            if (_jumpCount == 1)
                _yVelocity = _jumpHeight;
            if (_jumpCount == 2)
                _yVelocity += _jumpHeight;
        }
    }

    private void CalculateMovement()
    {
        _direction = new Vector3(_walk, 0, 0);
        var velocity = _direction * _speed;
        if (!_controller.isGrounded)
            _yVelocity -= _gravity;

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);

        if (_controller.isGrounded)
            _jumpCount = 0;
    }

    public void UpdateCoins(int amount)
    {
        _coinCount += amount;
        UIManager.Instance.UpdateCoinText(_coinCount);
    }

    public void UpdateLives(int amount)
    {
        _lives += amount;
        
        UIManager.Instance.UpdateLivesText(_lives);

        if (_lives <= 0)
        {
            GameManager.Instance.GameOver();
            UIManager.Instance.GameOverText();
        }
    }
}
