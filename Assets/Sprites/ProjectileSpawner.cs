using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private float fireProjectileInterval = 2f;
    private GameObject playerCharacter;
    [SerializeField] private GameObject fireProjectile;
    [SerializeField] GameObject enemies;
    Vector3 closestEnemyDirection = new Vector3(0f, 0f);
    private float projectileSpawnOffset = 0.5f;

    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine( spawnProjectile(fireProjectileInterval) );
    }


    private IEnumerator spawnProjectile( float interval )
    {
        yield return new WaitForSeconds(interval);

        Transform closestEnemy;
        int enemiesCount = enemies.transform.childCount;
        if (enemiesCount > 0 && playerCharacter)
        {
            float minDistance = Vector2.Distance(playerCharacter.transform.position, enemies.transform.GetChild(0).transform.position);
            int closestEnemyIndex = 0;

            for (var i = 1; i < enemiesCount; i++)
            {
                float dist = Vector2.Distance(playerCharacter.transform.position, enemies.transform.GetChild(i).transform.position);
                enemies.transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;

                if (dist < minDistance)
                {
                    closestEnemyIndex = i;
                    minDistance = dist;
                }
            }

            closestEnemy = enemies.transform.GetChild(closestEnemyIndex);

            // DEBUG ONLY 
            // Color color;
            // ColorUtility.TryParseHtmlString("#4CFFF6", out color);
            // enemies.transform.GetChild(closestEnemyIndex).GetComponent<SpriteRenderer>().color = color;

            closestEnemyDirection = (closestEnemy.position - playerCharacter.transform.position).normalized;

            GameObject newProjectile = Instantiate(fireProjectile, playerCharacter.transform.position, Quaternion.identity);
            newProjectile.transform.position += closestEnemyDirection * projectileSpawnOffset;
            FireProjectile newFireProjectile = newProjectile.GetComponent<FireProjectile>();
            newFireProjectile.setDirection(closestEnemyDirection);
            newFireProjectile.setPlayerCharacter(playerCharacter);

            float angle = Vector2.SignedAngle(Vector2.down, closestEnemyDirection);
            newProjectile.transform.eulerAngles = new Vector3(0, 0, angle);

            newProjectile.transform.parent = this.transform;
        }

        StartCoroutine( spawnProjectile(interval) );
    }
}
