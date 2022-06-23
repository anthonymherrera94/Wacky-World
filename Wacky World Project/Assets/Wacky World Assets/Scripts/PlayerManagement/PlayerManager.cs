using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerManagement {
    public class PlayerManager : MonoBehaviour {

        public GameObject Hero;
        public Checkpoints checkpointscript;

        public static PlayerManager Instance { get; protected set; }

        private int _health = 3;
        public int Health {
            get => _health;
            set {
                _health = value < 0 ? 0 : value;
                OnHealthChanged?.Invoke(_health);
                if (_health == 0 && checkpointscript.CurrentCheckpoint == null)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // Debug.Log($"Health: {_health}");
            }
        }
        private int _score;
        public int Score {
            get => _score;
            set {
                _score = value < 0 ? 0 : value;
                OnScoreChanged?.Invoke(_score);
            }
        }

        #region Events

        public delegate void HealthChanged(int health);
        public event HealthChanged OnHealthChanged;
        public delegate void ScoreChanged(int score);
        public event ScoreChanged OnScoreChanged;

        #endregion

        void Awake() {
            if (Instance == null)
                Instance = this;
            else
                Destroy(Instance);
            Instance = this;
        }
    }
}
