using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    [SerializeField]
    private float _puzzleCompleteDistance = 0.25f;
    [SerializeField]
    private Material _puzzleCompletedMaterial;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        if (_renderer == null)
            Debug.LogError("There is no material renderer assigned.");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Moving Box")
        {
            if(Vector3.Distance(this.transform.position, other.transform.position) <= _puzzleCompleteDistance)
            {
                _renderer.material = _puzzleCompletedMaterial;
                Rigidbody rb = other.transform.GetComponent<Rigidbody>();
                if (rb != null)
                    Destroy(rb);

                Destroy(this);
            }
        }
    }
}
