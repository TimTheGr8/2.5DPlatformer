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
    [SerializeField]
    private float _pushPower = 2.5f;

    private CharacterController _controller;
    private Vector3 _direction;
    private Vector3 _velocity;
    private Vector3 _wallSurfaceNormal;
    private float _walk = 0;
    private float _yVelocity = 0;
    private int _jumpCount = 0;
    private int _coinCount = 0;
    private int _lives;
    private bool _canWallJump = false;

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
        if(_canWallJump)
        {
            _yVelocity = _jumpHeight;
            _velocity = _wallSurfaceNormal * _speed;
            return;
        }
        if (_jumpCount < 1 && !_canWallJump)
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
        if (!_controller.isGrounded)
            _yVelocity -= _gravity;

        if (_controller.isGrounded)
        {
            _direction = new Vector3(_walk, 0, 0);
            _jumpCount = 0;
            _canWallJump = false;
            _velocity = _direction * _speed;
        }

        _velocity.y = _yVelocity;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Moving Box")
        {
            Rigidbody rb = hit.gameObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, 0);
                rb.velocity = pushDir * _pushPower;
            }
        }

        if(!_controller.isGrounded && hit.transform.tag == "Wall")
        {
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
            _canWallJump = true;
            _wallSurfaceNormal = hit.normal;
        }
    }

    public void UpdateCoins(int amount)
    {
        _coinCount += amount;
        UIManager.Instance.UpdateCoinText(_coinCount);
    }

    public int CoinCount()
    {
        return _coinCount;
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
