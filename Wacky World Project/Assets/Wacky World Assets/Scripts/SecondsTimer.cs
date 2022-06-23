using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SecondsTimer : MonoBehaviour
{
    [FormerlySerializedAs("Seconds")] public int Duration = 20;
    public bool startOnLoad = true;
    public UnityEvent<int> onTick;
    public UnityEvent onTimeout;
    private WaitForSeconds wait = new WaitForSeconds(1);

    void Start()
    {
        if (startOnLoad)
        {
            StartTimer();
        }
    }

    private void StartTimer()
    {
        StartCoroutine(InitiateCounting());
    }

    private IEnumerator InitiateCounting()
    {
        var remainding = Duration;
        onTick?.Invoke(remainding);
        while (remainding > 0)
        {
            yield return wait;
            remainding -= 1;
            onTick?.Invoke(remainding);
        }

        onTimeout?.Invoke();
    }
}