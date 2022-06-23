using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public  delegate void Die(Enemy enemy);
    public event Die OnDie;


    public void Kill()
    {
        OnDie?.Invoke(this);
        Destroy(gameObject);
    }
}
