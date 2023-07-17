using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    public Text Wave;

    void Update()
    {
        Wave.text = "Wave: " + EnemyManager.wave + "/10";
    }
}
