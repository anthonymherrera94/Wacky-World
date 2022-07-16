using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuggetBomb : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(gameObject);

            GameManager.Instance.MiniGameManager.GoBackToWorldLevel();
        }
    }
}
