using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerV2 : MonoBehaviour
{
    [SerializeField] private GameObject enemyGoblinPrefab;
    [SerializeField] private GameObject enemyGoblinBigPrefab;
    [SerializeField] private GameObject enemyBatPrefab;
    private int initialSpawnAmount = 3;

    [SerializeField] private float enemyGoblinInterval;
    [SerializeField] private float enemyGoblinBigInterval;
    [SerializeField] private float enemyBatInterval;

    [SerializeField] private float intervalVariation = 0.5f;


    // Start is called before the first frame update
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

        StartCoroutine(spawnEnemy(enemyGoblinInterval, enemyGoblinPrefab));
        //StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab));


    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        float safeDistance = 10.5f;
        float maxX = 12f;
        float maxY = 6f;

        float currentInterval = interval + 1 + Random.Range(-intervalVariation, intervalVariation);

        Debug.Log(currentInterval);

        yield return new WaitForSeconds(currentInterval);
        Vector2 spawnPosition = RandomRangeClamped(maxX, maxY, safeDistance);
        GameObject newEnemy = Instantiate(enemy, new Vector3(spawnPosition.x, spawnPosition.y, 0), Quaternion.identity);
        newEnemy.transform.parent = this.transform;
        StartCoroutine(spawnEnemy(interval, enemy));
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
