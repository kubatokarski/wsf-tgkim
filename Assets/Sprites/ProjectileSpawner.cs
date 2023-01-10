using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private float fireProjectileInterval = 1;
    private GameObject playerCharacter;
    [SerializeField] private GameObject fireProjectile;
    [SerializeField] GameObject enemies;


    void Start()
    {
        StartCoroutine( spawnProjectile( fireProjectileInterval, new Vector3(0f, 0f), new Vector3 (1f, 1f)) );
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        
    }


    private IEnumerator spawnProjectile( float interval, Vector3 spawnPosition, Vector3 direction )
    {
        Transform closestEnemy;
        int enemiesCount = enemies.transform.childCount;
        if (enemiesCount > 0)
        {
            Debug.Log("Finding closest enemy...");
            float minDistance = Vector2.Distance(this.transform.position, enemies.transform.GetChild(0).transform.position);
            int closestEnemyIndex = 0;

            for (var i = 1; i < enemiesCount; i++)
            {
                float dist = Vector2.Distance(this.transform.position, enemies.transform.GetChild(i).transform.position);
                if (dist < minDistance)
                {
                    closestEnemyIndex = i;
                    minDistance = dist;
                }
            }

            closestEnemy = enemies.transform.GetChild(closestEnemyIndex);

            Color color;
            ColorUtility.TryParseHtmlString("#4CFFF6", out color);
            enemies.transform.GetChild(closestEnemyIndex).GetComponent<SpriteRenderer>().color = color;

            Vector3 closestEnemyDirection = (closestEnemy.position - this.transform.position).normalized;
        }

        yield return new WaitForSeconds(interval);
        Debug.Log("spawning projectile");
        GameObject newProjectile = Instantiate(fireProjectile, playerCharacter.transform.position, Quaternion.identity);
        newProjectile.transform.parent = this.transform;
        FireProjectile newFireProjectile = newProjectile.GetComponent<FireProjectile>();
        newFireProjectile.setDirection(new Vector3(1f, 1f, 0) );
                
        StartCoroutine( spawnProjectile(interval, spawnPosition, direction) );
    }
}
