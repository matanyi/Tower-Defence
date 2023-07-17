using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreboard : MonoBehaviour
{
    public Text textElement;
    void Update()
    {
        if (PlayerPrefs.GetString("SavedScores") != null)
        {
            string textValue = PlayerPrefs.GetString("SavedScores");
            textElement.text = textValue;
        }
    }
}
