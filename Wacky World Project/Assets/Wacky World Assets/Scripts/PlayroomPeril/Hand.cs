using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    private Transform rightHand;

    public bool HasEmptyHand { get { return rightHand.childCount == 0; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PickUp(GameObject go)
    {
        if (HasEmptyHand)
        {
            go.transform.parent = rightHand;
        }
    }

    public Transform GetRightHand()
    {
        return rightHand.GetChild(0);
    }
}
