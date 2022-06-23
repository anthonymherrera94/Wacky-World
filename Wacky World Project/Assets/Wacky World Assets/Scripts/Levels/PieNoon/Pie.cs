using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Throwable))]
public class Pie : MonoBehaviour, IThrowable
{
    
    public void OnCollide(GameObject hit)
    {
        if (hit.CompareTag("Enemy"))
            hit.GetComponent<Enemy>().Kill();

        gameObject.SetActive(false);
    }

   

}
