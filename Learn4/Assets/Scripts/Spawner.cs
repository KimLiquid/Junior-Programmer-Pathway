using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabsEnemy;
    public GameObject prefabsPowerUp;
    private float SpawnRange = 9.0f;
    public int enemyCount;
    public int wave = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(wave);
        Instantiate(prefabsPowerUp, GenSpawnPos(), prefabsEnemy.transform.rotation);
    }

    void SpawnEnemyWave(int EnemySpawn)
    {
        for (int i = 0; i < EnemySpawn; i++)
        {
            Instantiate(prefabsEnemy, GenSpawnPos(), prefabsEnemy.transform.rotation);
        }
    }

    private Vector3 GenSpawnPos()
    {
        float SpawnPosX = Random.Range(-SpawnRange, SpawnRange);
        float SpawnPosZ = Random.Range(-SpawnRange, SpawnRange);

        return new Vector3(SpawnPosX, 0f, SpawnPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            wave++;
            SpawnEnemyWave(wave);
            Instantiate(prefabsPowerUp, GenSpawnPos(), prefabsEnemy.transform.rotation);
        }
            
    }
}
