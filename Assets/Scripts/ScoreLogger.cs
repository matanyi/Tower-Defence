using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogger : MonoBehaviour
{
    public string player_name;
    public int score;
    public EnterYourName input;

    private string name = "SavedScores";
    private string list;

    public void SaveScore()
    {
        list = PlayerPrefs.GetString(name) + player_name + " " + score.ToString() + "\n";
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
        score = MageManager.total_score;
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