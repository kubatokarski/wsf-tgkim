using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    private float timeToAttack = 2f;
    private float timer = 0f;

    [SerializeField] GameObject enemies;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timeToAttack)
        {
            timer = 0;

            Debug.Log("Range Attack placeholder");

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

                enemies.transform.GetChild(closestEnemyIndex).GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
        
    }
}
