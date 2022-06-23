using Managers;
using PlayerManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyChest : MonoBehaviour
{
    [SerializeField]
    private ToyType type;
    int numberOfToys = 0;

    public GameObject BlueShard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Add(PlayroomPerilToyScript toy)
    {
        numberOfToys++;
        Destroy(toy.gameObject);
        if (numberOfToys >= 5)
            BlueShard.SetActive(true);
    }
}
