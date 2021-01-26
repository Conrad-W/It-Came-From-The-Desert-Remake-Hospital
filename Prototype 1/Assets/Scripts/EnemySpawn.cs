using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (enemyCount < 1)
        {
            Instantiate(enemy, new Vector3(-2.75f,76.0f,7.5f), Quaternion.identity);
            enemyCount++;
        }
        yield return null;

    }
}
