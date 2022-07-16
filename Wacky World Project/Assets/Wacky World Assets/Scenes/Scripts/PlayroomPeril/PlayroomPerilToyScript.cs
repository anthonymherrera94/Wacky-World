using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToyType { Bear, Bunny, Car }
public class PlayroomPerilToyScript : Throwable, IThrowable
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Toy;
    [SerializeField] private GameObject Hand1;
    public ToyThrow toythrow;

    private bool InHand;

    public void OnCollide(GameObject hit)
    {
        if (hit.CompareTag("Chest"))
        {
            ToyChest chest = hit.GetComponent<ToyChest>();
            if (chest)
                chest.Add(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Hand hand = collision.transform.GetComponent<Hand>();
            if (hand && hand.HasEmptyHand && Time.time > toythrow.nextThrow)
                hand.PickUp(gameObject);
                InHand = true;
        }
    }

    private void Start()
    {
        InvokeRepeating("toggleToy", Random.Range(5f, 10f), Random.Range(5f, 10f));
    }

    private void Update()
    {
        if (Hand1.transform.childCount == 0)
        {
            InHand = false;
        }
    }

    void toggleToy()
    {
        if (InHand == false) 
        {
            Toy.SetActive(!isActiveAndEnabled);
        }

        if (InHand == true)
        {
            Toy.SetActive(true);
        }
    }
}
