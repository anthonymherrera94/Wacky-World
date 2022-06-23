using Collectables;
using PlayerManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShardPanel : MonoBehaviour
{
    [SerializeField]
    private Image[] images;

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.Hero.GetComponent<Collector>().OnShardChanged += OnShardChanged;
    }

    private void OnShardChanged(bool red, bool green, bool blue)
    {
        images[1].gameObject.SetActive(red);
        images[2].gameObject.SetActive(green);
        images[3].gameObject.SetActive(blue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        //PlayerManager.Instance.Hero.GetComponent<Collector>().OnShardChanged -= OnShardChanged;
    }
}
