using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class NewBlueShard2 : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            GameManager.Instance.MiniGameManager.GoBackToWorldLevel();
        }
    }
}
