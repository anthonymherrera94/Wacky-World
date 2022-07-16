using UnityEngine;
using UnityEngine.UI;

public class TextToNumber : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    public void SetText(int number)
    {
        text.text = number.ToString();
    }

}
