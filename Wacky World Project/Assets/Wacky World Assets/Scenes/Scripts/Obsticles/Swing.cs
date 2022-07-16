using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private float timePerSegment;

    private bool forward = true;
    private int last = 0;
    private int current = 1;
    private float nextTime;
    // Start is called before the first frame update
    void Start()
    {
        nextTime = Time.time + timePerSegment;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(waypoints[last].position, waypoints[current].position, 1-(nextTime-Time.time)/timePerSegment);

        if(Vector3.Distance(transform.position,waypoints[current].position)<0.1f)
            if (current >= (waypoints.Length - 1) || current==0)
            {
                last = current;
                current = (waypoints.Length - 1 )==current? current - 1:1 ;
                forward = !forward;

                nextTime = Time.time + timePerSegment;

            }
            else
            {
                last = current;
                current = current + (forward ? 1 : -1);

                nextTime = Time.time + timePerSegment;

            }    
    }
}
