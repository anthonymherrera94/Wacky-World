using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    private GameObject hit;
    private bool destroy;

    public void Throw(Vector3 start, Vector3 end, float speed, GameObject hit, bool destroy)
    {
        Debug.Log(hit);
        this.hit = hit;
        this.destroy = destroy;
        StartCoroutine(Move(start, end, speed));
    }

    public static Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

    IEnumerator Move(Vector3 start, Vector3 end, float speed)
    {
        float distance = Vector3.Distance(start, end);
        float current = 0;
        float duration = distance / speed;
        while (duration > current)
        {
            current += Time.deltaTime;
            transform.position = Parabola(start, hit ? hit.transform.position : end, 1, current / duration);

            yield return null;
        }
        if (hit)
        {
            OnHit();
        }

    }

    private void OnHit()
    {
        Debug.Log(hit);
        transform.GetComponent<IThrowable>().OnCollide(hit);

    }
}