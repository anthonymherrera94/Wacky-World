using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private BallBashManager manager;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ball")
        {
            manager.End();
            Debug.Log("GOOOOOOAL");
        }
    }
}
