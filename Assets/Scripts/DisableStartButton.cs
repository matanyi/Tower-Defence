using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableStart : MonoBehaviour
{
    public Button button;
   
    public void Started()
    {
        button.interactable = false;
    }
}
