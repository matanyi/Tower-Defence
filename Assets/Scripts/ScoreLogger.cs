using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogger : MonoBehaviour
{
    public string score, player_name;
    public EnterYourName input;
    private string name = "SavedScores";
    private string list;
    public void SaveScore()
    {
        list = PlayerPrefs.GetString(name) + player_name + " " + score + "\n";
        PlayerPrefs.SetString(name, list);
    }
    public void LoadScore()
    {
        Debug.Log(PlayerPrefs.GetString(name));
    }
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
        list = "";
    }
    void Update()
    {
        input = GameObject.FindGameObjectWithTag("Canvas").GetComponent<EnterYourName>();
        if (input.name_transfer != "")
        {
            player_name = input.name_transfer;
        }
        else
        {
            player_name = "---";
        }
    }
}