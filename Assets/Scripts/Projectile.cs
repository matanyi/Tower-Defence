using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed;
    public GameObject tower;
    TowerController script;
    EnemyController enemy;
    Vector3 destination;
    void Update()
    {
        script = transform.parent.GetComponent<TowerController>();
        destination = script.target.transform.position;
        enemy = script.target.GetComponent<EnemyController>();
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        float dist = Vector3.Distance(destination, transform.position);
        if (dist <= 0.00001)
        {
            enemy.Damage(damage);
            Destroy(gameObject);
        }
    }
}
