using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] points;
    public GameObject enemy;
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Instantiate(enemy, points[i].position, Quaternion.identity);
        }
        yield return null;

    }
}
