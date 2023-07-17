using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject Skeleton;
    public GameObject Devil;
    public GameObject Cyclops;
    public GameObject Boss;
    public static int wave;
    public GameObject[] enemy;
    public Text victory;

    private int timeSpawn = 30;
    private int[,] waves = new int[,] {
        {2, 1, 1, 1, 1},
        {2, 0, 1, 0, 0},
        {3, 0, 0, 0, 0},
        {3, 0, 0, 0, 0},
        {3, 0, 0, 0, 0},
        {3, 0, 0, 0, 0},
        {2, 0, 0, 0, 0},
        {2, 0, 0, 0, 0},
        {2, 0, 0, 0, 0},
        {3, 0, 0, 0, 0},
    };

    void Start()
    {
        wave = 0;
    }
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length == 0 && wave == 10)
        {
            Victory();
        }

    }
    private void StartSpawn()
    {
        StartCoroutine(Spawning());
    }
    private IEnumerator Spawning()
    {
        for (int i = 0; i < 10; i++)
        {
            UpdateWave();
            for (int j = 0; j < waves[i, 1]; j++)
            {
                SpawnEnemy(Skeleton);
                yield return new WaitForSeconds(waves[i, 0]);
            }
            for (int j = 0; j < waves[i, 2]; j++)
            {
                SpawnEnemy(Devil);
                yield return new WaitForSeconds(waves[i, 0]);
            }
            for (int j = 0; j < waves[i, 3]; j++)
            {
                SpawnEnemy(Cyclops);
                yield return new WaitForSeconds(waves[i, 0]);
            }
            for (int j = 0; j < waves[i, 4]; j++)
            {
                Instantiate(Boss, m_SpawnPoints[Random.Range(0, 1)]);
                yield return new WaitForSeconds(waves[i, 0]);
            }
            yield return new WaitForSeconds(timeSpawn);
        }
    }
    void SpawnEnemy(GameObject Enemy)
    {   
        Instantiate(Enemy, m_SpawnPoints[0]);
        Instantiate(Enemy, m_SpawnPoints[1]);
    }
    void UpdateWave()
    {
        wave++;
    }
    public void Victory()
    {
        Time.timeScale = 0;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemy.Length; ++i)
        {
            Destroy(enemy[i]);
        }
        victory.gameObject.SetActive(true);
    }
}