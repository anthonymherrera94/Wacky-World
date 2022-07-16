using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds references to all the sections and game boxes
/// </summary>
public class LevelReferences : MonoBehaviour
{
    private static LevelReferences instance;
    public static LevelReferences Instance { get { return instance; } }
    [SerializeField]
    private List<GameObject> sections;
    [SerializeField]
    private List<MiniGameTrigger> gameBoxes;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }
    public void SetSection(int index, bool active)
    {
        if (index >= sections.Count || index < 0) { Debug.Log("Section " + index + " does not exsist."); return; }
        sections[index].SetActive(active);
    }

    public void SetGameBox(int index, bool active)
    {
        if (index >= gameBoxes.Count || index < 0) { Debug.Log("Game Box " + index + " does not exsist."); return; }
        gameBoxes[index].gameObject.SetActive(active);
    }
}
