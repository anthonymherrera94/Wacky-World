using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PieNoonText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label;
    [SerializeField]
    private PieNoonLevelManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.OnEnemyCountChanged += OnEnemyCountChanged;
    }

    private void OnEnemyCountChanged(int num)
    {
        label.text = "Enemies: " + num;
    }

    // Update is called once per frame
}
