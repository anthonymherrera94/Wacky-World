using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NuggetPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private NuggetNabbingManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.OnNuggetsChanged += OnNuggetsChanged;
    }

    private void OnNuggetsChanged(int collected, int needed)
    {
        text.text = "" + collected + " / " + needed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
