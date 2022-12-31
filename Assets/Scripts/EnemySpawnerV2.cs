using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerV2 : MonoBehaviour
{
    [SerializeField] private GameObject swarmerPrefab;
    [SerializeField] private GameObject bigSwarmerPrefab;
    private int initialSpawnAmount = 3;

    [SerializeField] private float swarmerInterval = 3.5f;
    [SerializeField] private float bigSwarmerInterval = 10f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
        for(int i=0; i<initialSpawnAmount; i++)
        {
            spawnInitialEnemy(swarmerPrefab);
        }
        //StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 4f), 0), Quaternion.identity);
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
            float modifyXorY = Random.value;

            if (modifyXorY > 0.5)
            {
                result.x += Mathf.Sign(result.x) * min;
            } else
            {
                result.y += Mathf.Sign(result.y) * min;
            }
        }
        return result;

    }

}
