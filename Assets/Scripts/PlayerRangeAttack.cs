using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    private float timeToAttack = 2f;
    private float timer = 0f;

    [SerializeField] GameObject enemies;
    [SerializeField] FireProjectile projectile;

    void Start()
    {
        
    }

    void Update()
    {
        /*
        timer += Time.deltaTime;
        Transform closestEnemy;

        if(timer > timeToAttack)
        {
            timer = 0;

            int enemiesCount = enemies.transform.childCount;
            if (enemiesCount > 0) {
                
                float minDistance = Vector2.Distance( this.transform.position, enemies.transform.GetChild(0).transform.position);
                int closestEnemyIndex = 0;

                for(var i=1; i<enemiesCount; i++)
                {
                    float dist = Vector2.Distance(this.transform.position, enemies.transform.GetChild(i).transform.position);
                    if(dist < minDistance) {
                        closestEnemyIndex = i;
                        minDistance = dist;
                    }
                }
                closestEnemy = enemies.transform.GetChild(closestEnemyIndex);

                Color color;
                ColorUtility.TryParseHtmlString("#4CFFF6", out color);
                enemies.transform.GetChild(closestEnemyIndex).GetComponent<SpriteRenderer>().color = color;

                Vector3 direction = (closestEnemy.position - this.transform.position).normalized;
            }
        }
        */
    }
}