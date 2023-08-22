using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        CalculateMovement();
    }

    public void SetWalk(float walk)
    {
        _direction = new Vector3(walk, 0, 0);
    }

    private void CalculateMovement()
    {
        var charVeloctiy = _direction * _speed;
        _controller.Move(charVeloctiy * Time.deltaTime);
    }
}
