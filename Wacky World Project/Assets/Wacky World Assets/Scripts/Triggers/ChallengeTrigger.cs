using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Challenge { BallBash }
public class ChallengeTrigger : MonoBehaviour
{
    [SerializeField]
    private Challenge challenge;
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            SceneManager.LoadSceneAsync(challenge.ToString(), LoadSceneMode.Additive);
        }
    }
}
