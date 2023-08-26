using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.5f;
    [SerializeField]
    private Transform _pointA;
    [SerializeField]
    private Transform _pointB;
    [SerializeField]
    private Transform _currentTarget;


    private void Start()
    {
        if (_currentTarget == null)
            _currentTarget = _pointB;
    }
    private void FixedUpdate()
    {
        var step = _speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, _currentTarget.position, step);
        if(Vector3.Distance(this.transform.position, _currentTarget.position) < 0.25f)
        {
            ChangeTarget();
        }
    }

    private void ChangeTarget()
    {
        if (_currentTarget == _pointA)
        {
            _currentTarget = _pointB;
            return;
        }
        if (_currentTarget == _pointB)
        {
            _currentTarget = _pointA;
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
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
