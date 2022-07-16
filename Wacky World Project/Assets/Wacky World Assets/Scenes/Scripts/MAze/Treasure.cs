using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] GameObject Treasuree;
    public MazeCompleted MazeCompletedScript;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(Treasuree);
            MazeCompletedScript.Increment();
        }
    }
}
