using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float armor;
    public float health;
    public float mana;

    private int currentWayPoint;
    private GameObject[] wayPoints;
    private Vector2 target;


    void Start()
    {
        wayPoints = GameObject.FindGameObjectsWithTag(gameObject.transform.parent.gameObject.name);
        currentWayPoint = 0;
        target = wayPoints[currentWayPoint].transform.position;
    }

    void Update()
    {
        Debug.Log(transform.position);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        float dist = Vector2.Distance(target, transform.position);
        if (dist <= 0.00001)
        {
            currentWayPoint++;
            target = wayPoints[currentWayPoint].transform.position;
        }
    }
}
