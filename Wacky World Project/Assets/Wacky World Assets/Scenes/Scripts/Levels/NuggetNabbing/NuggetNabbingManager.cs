using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NuggetNabbingManager : MonoBehaviour {
    [SerializeField]
    private NuggetTimer timer;
    [SerializeField]
    private GameObject nuggetPrefab;
    [SerializeField]
    private GameObject bombPrefab;

    [SerializeField]
    private Transform nuggetPool;
    [SerializeField]
    private int boardWidth = 20;
    [SerializeField]
    private int boardHeight = 20;

    [SerializeField]
    private int numberOfNuggets = 10;

    [SerializeField]
    private float duration = 60;

    private float endTime;
    private float nextDrop;
    private float nextFalseDrop;

    private List<int> tilesPicked = new List<int>();

    private int numOfCollectedNuggets = 0;
    public delegate void NuggetsChanged(int collected, int needed);
    public event NuggetsChanged OnNuggetsChanged;

    public GameObject BlueShard;

    private void Start()
    {
        endTime = Time.time + duration;
        timer.SetTimer(duration);
    }

    private void Update()
    {
        if (Time.time > endTime) End();

        if (Time.time > nextDrop)
            DropNugget();
        if (Time.time > nextFalseDrop)
            DropBomb();
    }

    private void DropNugget()
    {
        int slot = PickSlot();
        

        CollectableNugget nugget = Instantiate(nuggetPrefab, new Vector3(slot % boardWidth, 5, Mathf.Floor(slot / boardWidth)), Quaternion.identity, nuggetPool).GetComponent<CollectableNugget>();
        nugget.OnPicked += NuggetPicked;

        nextDrop = Time.time + Random.Range(2f, 3f);
    }


    private void NuggetPicked(CollectableNugget nugget)
    {
        nugget.OnPicked -= NuggetPicked;
        numOfCollectedNuggets++;

        OnNuggetsChanged?.Invoke(numOfCollectedNuggets,numberOfNuggets);

        if (numOfCollectedNuggets >= numberOfNuggets)
            BlueShard.SetActive(true);

    }

    private void DropBomb()
    {
        int slot = PickSlot();

        GameObject nugget = Instantiate(bombPrefab, new Vector3(slot % boardWidth, 5, Mathf.Floor(slot / boardWidth)), Quaternion.identity, nuggetPool);

        tilesPicked.Add(slot);

        nextFalseDrop = Time.time + Random.Range(2f, 3f);
    }

    private int PickSlot()
    {
        int slot;

        if (tilesPicked.Count > (boardWidth * boardHeight * 0.8f))
            return Random.Range(0, boardHeight * boardWidth);
        else
        {
            while (true)
            {
                slot = Random.Range(0, boardHeight * boardWidth);
                if (!tilesPicked.Contains(slot)) break;
            }
        }

        return slot;
    }
    private void End()
    {
        GameManager.Instance.MiniGameManager.GoBackToWorldLevel();
    }
}
