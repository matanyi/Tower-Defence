using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MageManager : MonoBehaviour
{ 
    public static int mage_mana;
    public static int total_score;
    public static int castle_health;
    public Text defeat;
    public GameObject[] enemy;
    public Button blue_button, red_button, yellow_button, green_button;
    public static int blue_tower_cost, red_tower_cost, yellow_tower_cost, green_tower_cost;

    private int starting_mana;
    
    void Start()
    {
        castle_health = 20;
        mage_mana = 1000;
        total_score = 0;
        GameObject blue_tower = GameObject.Find("blue");
        TowerController script = blue_tower.GetComponent<TowerController>();
        blue_tower_cost = script.cost;
        GameObject red_tower = GameObject.Find("red");
        script = red_tower.GetComponent<TowerController>();
        red_tower_cost = script.cost;
        GameObject green_tower = GameObject.Find("green");
        script = green_tower.GetComponent<TowerController>();
        green_tower_cost = script.cost;
        GameObject yellow_tower = GameObject.Find("yellow");
        script = yellow_tower.GetComponent<TowerController>();
        yellow_tower_cost = script.cost;
    }

    void Update()
    {
        if(castle_health <= 0)
        {
            Defeat();
        }
        if (mage_mana >= blue_tower_cost) blue_button.interactable = true;
        else blue_button.interactable = false;
        if (mage_mana >= red_tower_cost) red_button.interactable = true;
        else red_button.interactable = false;
        if (mage_mana >= yellow_tower_cost) yellow_button.interactable = true;
        else yellow_button.interactable = false;
        if (mage_mana >= green_tower_cost) green_button.interactable = true;
        else green_button.interactable = false;
    }

    public void GameStarted()
    {
        StartCoroutine(ManaInflux());
    }

    private IEnumerator ManaInflux()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            mage_mana++;
        }
    }

    public void DamageCastle(int damage)
    {
        castle_health -= damage;
    }

    public void AddScore(int score_to_add)
    {
        total_score += score_to_add;
    }

    public void ChangeMana(int mana_difference)
    {
        mage_mana += mana_difference;
    }

    public void Defeat()
    {
        Time.timeScale = 0;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemy.Length; ++i)
        {
            Destroy(enemy[i]);
        }
        defeat.gameObject.SetActive(true);
    }
}
