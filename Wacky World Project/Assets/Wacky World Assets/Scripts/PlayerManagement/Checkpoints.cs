using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerManagement;
using UnityEngine.SceneManagement;
public class Checkpoints : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    public PlayerManager playermanager1;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            CurrentCheckpoint = other.gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            transform.position = CurrentCheckpoint.transform.position;
        }

        if(playermanager1.Health == 0)
        {
            transform.position = CurrentCheckpoint.transform.position;
            playermanager1.Health = 3;
        }
    }
}
