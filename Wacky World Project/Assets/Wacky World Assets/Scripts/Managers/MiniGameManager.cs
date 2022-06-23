using PlayerManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MiniGame
{
    Random,
    PieNoon,
    PartyPal
}

public class MiniGameManager
{
    private Vector3 position = Vector3.zero;
    private int sceneIndex = 0;
    private bool reposition = false;
    private List<int> openBoxes = new List<int>();

    public MiniGameManager()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    ~MiniGameManager()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void PlayMiniGame(MiniGame miniGame, int boxID)
    {
        if (openBoxes.Contains(boxID)) Debug.LogWarning("Something went wrong you already opened box " + boxID);

        openBoxes.Add(boxID);
        this.position = PlayerManager.Instance.Hero.transform.position;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadMiniGame(miniGame);
    }
    public void GoBackToWorldLevel()
    {
        if (position == Vector3.zero && sceneIndex == 0)
        {
            Debug.Log("Didn't came from world level");
            return;
        }

        reposition = true;
        SceneManager.LoadScene(sceneIndex);
    }

    private static void LoadMiniGame(MiniGame miniGame)
    {
        switch (miniGame)
        {
            case MiniGame.Random:
                SceneManager.LoadScene("Wacky Level 3 - Pie Arena");
                break;
            case MiniGame.PieNoon:
                SceneManager.LoadScene("Wacky Level 3 - Pie Arena");
                break;
            case MiniGame.PartyPal:
                SceneManager.LoadScene("Party Pals Panic Test");
                break;
            default:
                Debug.LogWarning("Error in loading minigame");
                break;
        }
    }


    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log("Loaded " + arg0.name + " hero " + PlayerManager.Instance?.Hero);

        if (reposition)
        {
            openBoxes.ForEach(x => LevelReferences.Instance.SetGameBox(x, false));
            PlayerManager.Instance.Hero.transform.position = position;
        }

        reposition = false;
    }
}