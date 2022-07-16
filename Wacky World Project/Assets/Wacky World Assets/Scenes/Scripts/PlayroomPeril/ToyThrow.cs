using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyThrow : Ability
{
    [SerializeField]
    private Hand hand;
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float maxThrowDistance = 10f;
    [SerializeField]
    private Throwable toy;
    [SerializeField]
    private Transform spawnPoint;

    private RaycastHit hit;
    public float nextThrow;
    private float cooldDown;
    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<Hand>();
        nextThrow = Time.time;
        cooldDown = maxThrowDistance / speed;
    }

    public override void Use()
    {
        if (Time.time < nextThrow && !hand.HasEmptyHand) return;

        toy = hand.GetRightHand().GetComponent<Throwable>();
        toy.transform.parent = null;

        nextThrow = Time.time + cooldDown;

        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit, maxThrowDistance, ~LayerMask.GetMask("Projectil")))
        {
            toy.Throw(spawnPoint.position, hit.point, speed, hit.transform.gameObject, false);
        }
        else
            toy.Throw(spawnPoint.position, spawnPoint.position + spawnPoint.forward * maxThrowDistance, speed, null, false);
        Debug.DrawRay(spawnPoint.position, spawnPoint.forward, Color.green, 3f);
        toy.transform.rotation = Quaternion.FromToRotation(toy.transform.up, spawnPoint.forward) * toy.transform.rotation;

        toy = null;
    }

}
