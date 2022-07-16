using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isUnlockable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Door unlocking");
        if (!isUnlockable)
        {
            Debug.Log("This Door can't be opened");
            return false;
        }
        if (LockdownManager.Instance.HasKey)
            LockdownManager.Instance.DoorUnlocked();
        else
            Debug.Log("You Don't Have The key");

        return LockdownManager.Instance.HasKey;
    }

    public void Unlocable()
    {
        isUnlockable = true;
    }
}
