using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Animator anim;
    private bool opened = false;
    private bool containsKey = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool Interact(Interactor interactor)
    {
        if (opened)
            anim.SetTrigger("Close");
        else
            anim.SetTrigger("Open");

        opened = !opened;

        if (containsKey)
            LockdownManager.Instance.KeyFound();

        return true;
    }

    internal void Add(PlayroomPerilToyScript playroomPerilToyScript)
    {
        throw new NotImplementedException();
    }

    public void PlaceKey()
    {
        containsKey = true;
    }
}
