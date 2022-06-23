using PlayerManagement;
using TMPro;
using UnityEngine;

namespace ScoreSystem {
    public class ScorePanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        void Start() {
            PlayerManager.Instance.OnScoreChanged += OnScoreChanged;
        }

        private void OnScoreChanged(int score) {
            scoreText.text = score.ToString();
        }

    }
}
