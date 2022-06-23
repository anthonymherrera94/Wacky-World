using System;
using UnityEngine;

namespace ScoreSystem
{
    [Obsolete("Moved to PlayerManager.cs")]
    public class ScoreManager : MonoBehaviour
    {
        // public static ScoreManager Instance { get; protected set; }

        // private int score;

        // public delegate void ScoreChanged(int score);
        // public event ScoreChanged OnScoreChanged;

        // void Awake()
        // {
        //     if (Instance == null)
        //         Instance = this;
        //     else
        //         Destroy(Instance);
        // }

        // public void AddPoints(int amount)
        // {
        //     score += amount;
        //     OnScoreChanged?.Invoke(score);
        // }

        // public void SetPoints(int points)
        // {
        //     score = points;
        //     OnScoreChanged?.Invoke(score);
        // }

        // public void ResetScore()
        // {
        //     score = 0;
        //     OnScoreChanged?.Invoke(score);
        // }
    }
}
