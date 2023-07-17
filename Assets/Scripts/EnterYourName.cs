using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterYourName : MonoBehaviour
{
    public Text player_name;
    public string name_transfer;
    public void GetName()
    {
        Debug.Log(player_name.text);
    }
    void Update()
    {
        name_transfer = player_name.text;
    }
}
