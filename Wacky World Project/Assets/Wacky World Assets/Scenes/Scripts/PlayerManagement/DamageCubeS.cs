using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerManagement;

public class DamageCubeS : MonoBehaviour
{
    public PlayerManager playermanager2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playermanager2.Health -= 1;
        }
    }
}
