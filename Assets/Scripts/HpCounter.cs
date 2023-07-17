using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCounter : MonoBehaviour
{
    public Text Health;

    void Update()
    {
        Health.text = "Health: " + MageManager.castle_health;
    }
}
