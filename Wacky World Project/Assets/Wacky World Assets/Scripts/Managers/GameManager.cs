using SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance { get; protected set; }

        private GameData gameData;
        /// <summary>
        /// Use to determen if game is run from main menu or just single scene text.
        /// </summary>
        public bool IsTest { get { return gameData == null; } }
        private MiniGameManager miniGameManager = new MiniGameManager();
        public MiniGameManager MiniGameManager { get { return miniGameManager; } }

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }


        public void SetGameData(GameData gameData)
        {
            this.gameData = gameData;
        }

        public void CompleteLevel()
        {
            if (gameData == null) { Debug.Log("Game did not have gameDate, Game probablly didn't start from main menu"); return; }
            gameData.AdvanceLevel();
            SceneManager.LoadScene(gameData.SceneIndex);
        }

        private void OnApplicationQuit()
        {
            //GlobalSaveData.Save();
        }

        public void BackToWorld()
        {
            MiniGameManager.GoBackToWorldLevel();
        }
    }
}
