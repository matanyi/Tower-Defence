using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class MouseTest : MonoBehaviour
{
    public Button blue_button, red_button, yellow_button, green_button;
    public GameObject highlight;
    public GameObject blue_tower, red_tower, yellow_tower, green_tower;
    public RectTransform rect1, rect2;
    public Transform new_parent;

    PlacementCheck script;

    private GameObject[] towers, placements;
    private int x, y;
    private bool blue = false, red = false, yellow = false, green = false, collision;
    private void Awake()
    {
        blue_button.onClick.AddListener(delegate { blue = true; });
        red_button.onClick.AddListener(delegate { red = true; });
        green_button.onClick.AddListener(delegate { green = true; });
        yellow_button.onClick.AddListener(delegate { yellow = true; });
    }

    private bool Check(float x, float y)
    {
        bool check = false;
        Vector2 pos;
        pos = new Vector2(x, y);
        towers = GameObject.FindGameObjectsWithTag("Tower");
        for (int i = 0; i < towers.Length; ++i)
        {
            rect2 = towers[i].GetComponent<RectTransform>();
            Debug.Log(pos);
            Debug.Log(rect2.anchoredPosition);
            if (pos == rect2.anchoredPosition)
            {
                check = false;
                return check;
            }
        }
        placements = GameObject.FindGameObjectsWithTag("Placement");
        for (int i = 0; i < placements.Length; ++i)
        {
            script = placements[i].GetComponent<PlacementCheck>();
            if(script.inside)
            {
                check = true;
                return check;
            }
        }
        return check;
    }


    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        x = (int)(mousePosition.x * 58.592502620549679704084424765176f) + 960;
        x = x - (x % 60) + 30;
        x -= 960;
        y = (int)(mousePosition.y * 58.592502620549679704084424765176f) + 540;
        y = y - (y % 60) + 30;
        y -= 540;
        collision = Check((float)(x / 58.592502620549679704084424765176f), (float)(y / 58.592502620549679704084424765176f));
        if ((blue || red || yellow || green) && collision)
        {
            highlight.transform.position = new Vector3(x / 58.592502620549679704084424765176f, y / 58.592502620549679704084424765176f, 0);

            if (Input.GetMouseButtonDown(0) && blue)
            {
                GameObject blueTower = Instantiate(blue_tower, new Vector3(x / 58.592502620549679704084424765176f, y / 58.592502620549679704084424765176f, 0), Quaternion.identity) as GameObject;
                blue = false;
                MageManager.mage_mana -= MageManager.blue_tower_cost;
            }
            if (Input.GetMouseButtonDown(0) && red)
            {
                GameObject redTower = Instantiate(red_tower, new Vector3(x / 58.592502620549679704084424765176f, y / 58.592502620549679704084424765176f, 0), Quaternion.identity) as GameObject;
                red = false;
                MageManager.mage_mana -= MageManager.red_tower_cost;
            }
            if (Input.GetMouseButtonDown(0) && yellow)
            {
                GameObject yellowTower = Instantiate(yellow_tower, new Vector3(x / 58.592502620549679704084424765176f, y / 58.592502620549679704084424765176f, 0), Quaternion.identity) as GameObject;
                yellow = false;
                MageManager.mage_mana -= MageManager.yellow_tower_cost;
            }
            if (Input.GetMouseButtonDown(0) && green)
            {
                GameObject greenTower = Instantiate(green_tower, new Vector3(x / 58.592502620549679704084424765176f, y / 58.592502620549679704084424765176f, 0), Quaternion.identity) as GameObject;
                green = false;
                MageManager.mage_mana -= MageManager.green_tower_cost;
            }
        }
        else
        {
            highlight.transform.position = new Vector3(1000, 1000, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            blue = false;
            red = false;
            yellow = false;
            green = false;
        }
    }
}