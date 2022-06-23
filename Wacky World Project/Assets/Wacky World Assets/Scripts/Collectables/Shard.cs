using Collectables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
    [SerializeField]
    private ShardType type;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Collector c = GameObject.FindWithTag("Player").GetComponent<Collector>();

            c.AddShard(type);

            Destroy(gameObject);
        }
    }
}
