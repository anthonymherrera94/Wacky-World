using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBasher : Ability
{
    private int numberOfTinyBalls = 0;
    private int maxOfTinyBalls = 10;

    private bool canShootBigBall = false;

    private GameObject BigBall;
    private float shootForce = 30f;
    private void Start()
    {
        BigBall = Resources.Load<GameObject>("Ball Bash/Big Ball");
        BigBall = Instantiate(BigBall);
        BigBall.SetActive(false);
    }
    public override void Use()
    {
        if(canShootBigBall)
        {
            BigBall.SetActive(true);
            BigBall.transform.position = transform.position + transform.forward;
            BigBall.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
        }
    }
    
    public void AddBall()
    {
        numberOfTinyBalls++;
        if (numberOfTinyBalls >= maxOfTinyBalls)
            canShootBigBall = true;

        Debug.Log("Can Shoot big ball : " + canShootBigBall);
    }
}
