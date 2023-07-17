using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    public Text text;
    public void Hide()
    {
        text.gameObject.SetActive(false);
    }
    public void Show()
    {
        text.gameObject.SetActive(true);
    }
}
