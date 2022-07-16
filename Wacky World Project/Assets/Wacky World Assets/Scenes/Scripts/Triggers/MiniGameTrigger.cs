using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    [Tooltip("ID Needs to be same as order in LevelReference.")] 

    
    [SerializeField]
    private int boxID;
    [SerializeField]
    private MiniGame miniGame;
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            GameManager.Instance.MiniGameManager.PlayMiniGame(miniGame,boxID);
        }
    }
}
