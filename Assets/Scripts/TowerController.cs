using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public float range;
    public float fire_rate;
    public int cost;
    public CircleCollider2D collider;
    public GameObject projectile;
    public GameObject target;
    public bool is_yellow;

    EnemyController enemy;

    private int current_enemy;
    private GameObject[] enemies;
    List<GameObject> visible_enemies = new List<GameObject>();
    private bool looking_for_targets; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        visible_enemies.Add(other.gameObject);
        if (is_yellow)
        {
            enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.is_slowed = true;
            Debug.Log(enemy.is_slowed);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        visible_enemies.Remove(other.gameObject);
        if (is_yellow)
        {
            enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.is_slowed = false;
            Debug.Log(enemy.is_slowed);
        }
    }

    private void StartShooting()
    {
        StartCoroutine(Shooting());
        looking_for_targets = false;
    }

    private void StopShooting()
    {
        StopCoroutine(Shooting());
        looking_for_targets = true;
    }

    private IEnumerator Shooting()
    {
        while(visible_enemies.Count > 0)
        {
            Instantiate(projectile, transform);
            yield return new WaitForSeconds(fire_rate);
        }
    }

    void Start()
    {
        collider.radius = range;
        looking_for_targets = true;
    }

    void Update()
    {
        if (!is_yellow)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (visible_enemies.Count > 0)
            {
                target = visible_enemies[0];
                Debug.Log(target.transform.position);
                if (looking_for_targets)
                {
                    StartShooting();
                }
            }
            else
            {
                StopShooting();
            }
        }
    }
}
