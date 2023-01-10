using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject player;
    float timer;

    private void Awake()
    {
        int initialEnemies = 3;

        for (int i=0; i<initialEnemies; i++)
        {
            SpawnEnemy(false);
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            SpawnEnemy(true);
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy(bool spawnOutsideFOV)
    {
        Vector3 position = GenerateRandomPosition(spawnOutsideFOV);

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<EnemyV1_Old>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }

    private Vector3 GenerateRandomPosition(bool spawnOutsideFOV) {
        
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f ;

        if(spawnOutsideFOV)
        {
            if(UnityEngine.Random.value > 0.5f)
            {
                position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
                position.y = spawnArea.y * f;

            }
            else {
                position.x = spawnArea.x * f;
                position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            }
        } else {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
        }
        position.z = 0f;

        return position;
    }
}
