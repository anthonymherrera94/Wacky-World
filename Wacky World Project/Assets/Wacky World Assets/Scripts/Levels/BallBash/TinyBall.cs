using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyBall : MonoBehaviour
{
    public delegate void Picked(TinyBall ball);
    public event Picked OnPicked;
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<BallBasher>().AddBall();
            OnPicked?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
