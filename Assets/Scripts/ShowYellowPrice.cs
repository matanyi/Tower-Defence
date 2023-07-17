using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowYellowPrice : MonoBehaviour
{
    public Text price;

    void Update()
    {
        price.text = "Cost\n" + MageManager.yellow_tower_cost.ToString();
    }
}
