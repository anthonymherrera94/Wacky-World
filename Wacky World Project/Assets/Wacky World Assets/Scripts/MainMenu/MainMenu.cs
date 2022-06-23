using Managers;
using SaveSystem;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject newGamePanel;
        [SerializeField] private GameObject loadGamePanel;
        [SerializeField] private GameObject optionsPanel;

        [SerializeField] private TextMeshProUGUI[] newSlots;
        [SerializeField] private TextMeshProUGUI[] saveSlots;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                GameData data = GlobalSaveData.GetSave(i);
                if (data == null) continue;
                newSlots[i].text = data.Name;
                saveSlots[i].text = data.Name;
            }
        }

        public void StartNewGame(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex > 2)
            {
                Debug.Log("Something went wrong with slot index");
                return;
            }

            Debug.Log(slotIndex);


            GlobalSaveData.AddGame(slotIndex, "Game" + slotIndex);

            GameManager.Instance.SetGameData(GlobalSaveData.GetSave(slotIndex));

            SceneManager.LoadScene(1);
        }

        public void ResumeGame(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex > 2)
            {
                Debug.Log("Something went wrong with slot index");
                return;
            }

            Debug.Log(slotIndex);


            GameData data = GlobalSaveData.GetSave(slotIndex);
            GameManager.Instance.SetGameData(data);
            if (data != null)
                SceneManager.LoadScene(data.SceneIndex);
        }

        public void OpenNewGamePanel()
        {
            newGamePanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }

        public void OpenLoadGamePanel()
        {
            loadGamePanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }

        public void OpenMainMenuPanel()
        {
            newGamePanel.SetActive(false);
            loadGamePanel.SetActive(false);
            optionsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }

        public void OpenOptionsPanel()
        {
            optionsPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}