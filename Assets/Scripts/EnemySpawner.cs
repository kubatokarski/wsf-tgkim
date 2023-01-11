using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyGoblinPrefab;
    [SerializeField] private float enemyGoblinInterval;
    [SerializeField] private int enemyGoblinSpawnAmount;

    [SerializeField] private GameObject enemyBatPrefab;
    [SerializeField] private float enemyBatInterval;
    [SerializeField] private int enemyBatSpawnAmount;

    private int initialSpawnAmount = 3;
    [SerializeField] private float intervalVariation = 0.5f;

    void Start()
    {
        for (int i = 0; i < initialSpawnAmount; i++)
        {
            spawnInitialEnemy(enemyGoblinPrefab);
        }
        for (int i = 0; i < initialSpawnAmount * 1.5f; i++)
        {
            spawnInitialEnemy(enemyBatPrefab);
        }

        StartCoroutine(spawnEnemy(enemyGoblinInterval, enemyGoblinPrefab, enemyGoblinSpawnAmount));
        StartCoroutine(spawnEnemy(enemyBatInterval, enemyBatPrefab, enemyBatSpawnAmount));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy, int amount)
    {
        float safeDistance = 10.5f;
        float maxX = 12f;
        float maxY = 6f;

        float currentInterval = interval + Random.Range(-intervalVariation, intervalVariation);

        yield return new WaitForSeconds(currentInterval);

        for(var i=0; i<amount; i++)
        {
            Vector2 spawnPosition = RandomRangeClamped(maxX, maxY, safeDistance);
            GameObject newEnemy = Instantiate(enemy, new Vector3(spawnPosition.x, spawnPosition.y, 0), Quaternion.identity);
            newEnemy.transform.parent = this.transform;
        }
        StartCoroutine(spawnEnemy(interval, enemy, amount));
    }

    private void spawnInitialEnemy(GameObject enemy) {
        float safeDistance = 3f;
        float maxX = 8f;
        float maxY = 4.5f;

        Vector2 spawnPosition = RandomRangeClamped(maxX, maxY, safeDistance);

        GameObject newEnemy = Instantiate(enemy, new Vector3(spawnPosition.x, spawnPosition.y, 0), Quaternion.identity);
        newEnemy.transform.parent = this.transform;
    }

    private Vector2 RandomRangeClamped(float maxX, float maxY, float min)
    {
        Vector2 result = new Vector2();
        result.x = Random.Range(-maxX, maxX);
        result.y = Random.Range(-maxY, maxY);

        if(result.magnitude < min)
        {
            float ySign = Mathf.Sign(result.y);
            result = result.normalized * min;
            result.y = ySign * maxY;

        }

        return result;
    }

}
