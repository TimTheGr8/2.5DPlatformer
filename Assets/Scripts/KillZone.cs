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
            Player player = other.GetComponent<Player>();
            if (player != null)
                player.UpdateLives(-1);

            other.transform.position = _spawnLoaction.position;
        }
    }
}
