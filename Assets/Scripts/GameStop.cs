using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStop : MonoBehaviour
{
    public void StopGame()
    {
        Time.timeScale = 0;
    }
}
