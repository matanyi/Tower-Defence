using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowRedPrice : MonoBehaviour
{
    public Text price;

    void Update()
    {
        price.text = "Cost\n"+ MageManager.red_tower_cost.ToString();
    }
}
