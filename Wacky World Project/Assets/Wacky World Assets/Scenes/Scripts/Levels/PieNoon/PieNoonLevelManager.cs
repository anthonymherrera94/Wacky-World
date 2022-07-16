using Managers;
using PlayerManagement;
using ScoreSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieNoonLevelManager : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> enemies = new List<Enemy>();

    public delegate void EnemyCountChanged(int num);
    public event EnemyCountChanged OnEnemyCountChanged;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Enemy e in enemies)
            e.OnDie += OnEnemyDied;

        OnEnemyCountChanged?.Invoke(enemies.Count);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        PlayerManager.Instance.Score += 10;
        
        enemies.Remove(enemy);

        OnEnemyCountChanged?.Invoke(enemies.Count);

        if (enemies.Count == 0)
            BackToWorld();

    }

    public void BackToWorld()
    {
         GameManager.Instance.MiniGameManager.GoBackToWorldLevel();
    }

}
