using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float current_speed;
    public float health;
    public float current_health;
    public float armor;
    public int mana;
    public int score;
    public int damage;
    public GameObject HealthBar;
    public Slider slider;
    public bool is_slowed;

    private int currentWayPoint;
    private GameObject[] wayPoints;
    private Vector3 target;


    void Start()
    {
        is_slowed = false;
        current_speed = speed;
        current_health = health;
        slider.value = CalculateHealth();
        wayPoints = GameObject.FindGameObjectsWithTag(gameObject.transform.parent.gameObject.name);
        currentWayPoint = 0;
        target = wayPoints[currentWayPoint].transform.position;
    }

    public void Damage(float damage)
    {
        current_health = current_health + armor - damage;
        Debug.Log(current_health);
    }

    float CalculateHealth()
    {
        return current_health / health;
    }

    void Update()
    {
        slider.value = CalculateHealth();
        if(current_health < health)
        {
            HealthBar.SetActive(true);
        }
        if(current_health <= 0)
        {
            Destroy(gameObject);
            MageManager.total_score += score;
            MageManager.mage_mana += mana;
        }
        if(current_health > health)
        {
            current_health = health; 
        }
        if (is_slowed)
            current_speed = speed / 2;
        else
            current_speed = speed;
        transform.position = Vector3.MoveTowards(transform.position, target, current_speed * Time.deltaTime);
        float dist = Vector3.Distance(target, transform.position);
        if (dist <= 0.00001)
        {
            currentWayPoint++;
            target = wayPoints[currentWayPoint].transform.position;
        }
        if (currentWayPoint == wayPoints.Length - 1)
        {
            MageManager.castle_health -= damage;
            Destroy(gameObject);
        }
    }
}
