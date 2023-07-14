using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreboard : MonoBehaviour
{
    public Text textElement;
    void Start()
    {
        string textValue = PlayerPrefs.GetString("SavedScores");
        textElement.text = textValue;
    }
}
