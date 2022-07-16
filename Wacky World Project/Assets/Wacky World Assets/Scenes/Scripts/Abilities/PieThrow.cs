using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieThrow : Ability
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float maxThrowDistance = 10f;
    [SerializeField]
    private Throwable pie;
    [SerializeField]
    private Transform spawnPoint;
    
    private RaycastHit hit;
    private float nextThrow;
    private float cooldDown;
    // Start is called before the first frame update
    void Start()
    {
        
        pie = Instantiate(pie);
        nextThrow = Time.time;
        cooldDown = maxThrowDistance / speed;
    }

    public override void Use()
    {
        if (Time.time < nextThrow) return;

        nextThrow = Time.time + cooldDown;

        pie.gameObject.SetActive(true);

        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit, maxThrowDistance, ~LayerMask.GetMask("Projectil")))
        {
            pie.Throw(spawnPoint.position, hit.point, speed, hit.transform.gameObject, false);
        } else
            pie.Throw(spawnPoint.position, spawnPoint.position + spawnPoint.forward * maxThrowDistance, speed, null, false);
        Debug.DrawRay(spawnPoint.position, spawnPoint.forward, Color.green,3f);
        pie.transform.rotation = Quaternion.FromToRotation(pie.transform.up, spawnPoint.forward) * pie.transform.rotation;
    }
}
