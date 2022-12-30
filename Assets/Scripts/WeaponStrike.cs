using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStrike : MonoBehaviour
{
    [SerializeField] float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject WhipAttackL;
    [SerializeField] GameObject WhipAttackR;

    PlayerMovement playerMovement;
    [SerializeField] int axeDamage = 1;

    private void Awake ()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        playerMovement.lastHorizontalVector = 1;
        timer = timeToAttack;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) {
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;
        Vector2 WhipAttackPosition; 

        GameObject ActiveWhipAttack;
        Collider2D[] colliders;

        Vector3 AttackDimensions = new Vector3(1.6f, 1.2f);

        if( playerMovement.lastHorizontalVector > 0) {
            ActiveWhipAttack = WhipAttackR;
        } else {
            ActiveWhipAttack = WhipAttackL;
        }

        WhipAttackPosition = ActiveWhipAttack.transform.position;
        ActiveWhipAttack.SetActive(true);

        colliders = Physics2D.OverlapBoxAll(new Vector2(WhipAttackPosition.x - 0.5f * AttackDimensions.x, WhipAttackPosition.y - 0.5f * AttackDimensions.y),
                                            new Vector2(AttackDimensions.x, AttackDimensions.y), 0f);
        ApplyDamage(colliders);
        
        // DEBUG 
        DrawDebugRectangle ( new Vector2(WhipAttackPosition.x - 0.5f * AttackDimensions.x, WhipAttackPosition.y - 0.5f * AttackDimensions.y),
                             new Vector2(WhipAttackPosition.x + 0.5f * AttackDimensions.x, WhipAttackPosition.y - 0.5f * AttackDimensions.y),
                             new Vector2(WhipAttackPosition.x - 0.5f * AttackDimensions.x, WhipAttackPosition.y + 0.5f * AttackDimensions.y),
                             new Vector2(WhipAttackPosition.x + 0.5f * AttackDimensions.x, WhipAttackPosition.y + 0.5f * AttackDimensions.y), Color.red, 1 );
        
        drawCross(new Vector2(WhipAttackPosition.x - 0.5f * AttackDimensions.x, WhipAttackPosition.y - 0.5f * AttackDimensions.y), 0.05f, Color.white);
        drawCross(new Vector2(WhipAttackPosition.x + 0.5f * AttackDimensions.x, WhipAttackPosition.y + 0.5f * AttackDimensions.y), 0.05f, Color.white);
    }

    private void drawCross (Vector3 position, float crossLength, Color col, float time = 1f)
    {
        Debug.DrawLine( new Vector3(position.x - crossLength, position.y - crossLength, 0), 
                        new Vector3(position.x + crossLength, position.y + crossLength, 0), col, time);
        Debug.DrawLine( new Vector3(position.x - crossLength, position.y + crossLength, 0), 
                        new Vector3(position.x + crossLength, position.y - crossLength, 0), col, time);
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i=0; i<colliders.Length; i++) 
        {
            Enemy e = colliders[i].GetComponent<Enemy>();
            if(e != null)
            {
                colliders[i].GetComponent<Enemy>().TakeDamage(axeDamage);
            }
        }
    }

    private void DrawDebugRectangle (Vector3 LB, Vector3 RB, Vector3 LT, Vector3 RT, Color color, float duration)
    {
        Debug.DrawLine(LB, RB, color, duration);
        Debug.DrawLine(RB, RT, color, duration);
        Debug.DrawLine(RT, LT, color, duration);
        Debug.DrawLine(LT, LB, color, duration);
    }
}
