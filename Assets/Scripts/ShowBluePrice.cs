using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowBluePrice : MonoBehaviour
{
    public Text price;

    void Update()
    {
        price.text = "Cost\n" + MageManager.blue_tower_cost.ToString();
    }
}
