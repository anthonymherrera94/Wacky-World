using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NuggetTimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private float endTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (endTime != 0)
            text.text = Mathf.CeilToInt(endTime - Time.time).ToString();
    }

    public void SetTimer(float sec)
    {
        endTime = Time.time + sec;
    }
}
