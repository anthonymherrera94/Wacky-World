using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockdownManager : MonoBehaviour
{
    [SerializeField]
    private List<Chest> chests;
    [SerializeField]
    private List<Door> doors;
    [SerializeField]
    private GameObject Key;

    public bool HasKey { get; protected set; }
    public static LockdownManager Instance { get; protected set; }
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        chests[Random.Range(0, chests.Count)].PlaceKey();
        doors[Random.Range(0, doors.Count)].Unlocable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KeyFound()
    {
        HasKey = true;
        Key.SetActive(true);
    }

    public void DoorUnlocked()
    {
        GameManager.Instance.CompleteLevel();
    }
}
