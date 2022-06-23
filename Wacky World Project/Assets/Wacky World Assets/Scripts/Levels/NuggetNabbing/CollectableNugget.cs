using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableNugget : MonoBehaviour
{
    public delegate void Picked(CollectableNugget nugget);
    public event Picked OnPicked;
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            OnPicked?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
