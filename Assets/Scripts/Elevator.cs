using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private Transform _downPosition;
    [SerializeField]
    private Transform _upPosition;
    [SerializeField]
    private bool _startInUpPosition = true;

    private Transform _currentTarget;

    private void Start()
    {
        if (_startInUpPosition)
            _currentTarget = _upPosition;
        else
            _currentTarget = _downPosition;
    }

    private void FixedUpdate()
    {
        var step = _speed * Time.deltaTime;
        if(transform.position != _currentTarget.position)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, _currentTarget.position, step);
        }
    }

    public void MoveElevator()
    {
        if (transform.position == _downPosition.position)
            _currentTarget = _upPosition;
        else
            _currentTarget = _downPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
