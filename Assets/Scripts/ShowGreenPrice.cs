using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowGreenPrice : MonoBehaviour
{
    public Text price;

    void Update()
    {
        price.text = "Cost\n" + MageManager.green_tower_cost.ToString();
    }
}
