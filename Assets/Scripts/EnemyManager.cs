using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    public float timeSpawn = 2f;

    private float timer;

    void Start()
    {
        timer = timeSpawn;
    }
    
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeSpawn;
            Debug.Log("sadaddfad");
            Instantiate(m_EnemyPrefab,m_SpawnPoints[0]);
            Instantiate(m_EnemyPrefab, m_SpawnPoints[1]);
        }
    }
}
