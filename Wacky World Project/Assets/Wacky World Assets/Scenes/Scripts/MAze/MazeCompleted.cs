using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class MazeCompleted : MonoBehaviour
{
    public int TreasuresRequired = 5;
    public int TreasuresCollected;
    public GameObject BlueShard;

    public void Increment()
    {
        TreasuresCollected++;

        if(TreasuresCollected >= TreasuresRequired)
        {
            BlueShard.SetActive(true);
        }
    }
}
