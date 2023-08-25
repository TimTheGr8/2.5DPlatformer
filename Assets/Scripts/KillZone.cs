using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnLoaction;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.SetActive(false);
            other.transform.position = _spawnLoaction.position;
            other.gameObject.SetActive(true);
        }
    }
}
