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
    //[SerializeField] Vector2 whipAttackSize = new Vector2(1.0f, 0.7f);
    Vector2 whipAttackSize = new Vector2(1.8f, 1f);
    [SerializeField] int axeDamage = 1;

    LineRenderer l;

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

        GameObject debugWhipAttack;

        if( playerMovement.lastHorizontalVector > 0) {
            WhipAttackR.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(WhipAttackR.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
            
            // DEBUG
            debugWhipAttack = WhipAttackR;
        } else {
            WhipAttackL.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(WhipAttackL.transform.position - new Vector3(whipAttackSize.x, 0, 0), whipAttackSize, 0f);
            ApplyDamage(colliders);
            
            // DEBUG
            debugWhipAttack = WhipAttackL;                 
        }

        // DEBUG
        Vector3 LeftBottom;
        if (debugWhipAttack == WhipAttackR) {
            LeftBottom  = debugWhipAttack.transform.position;
        } else {
            LeftBottom  = debugWhipAttack.transform.position - new Vector3(whipAttackSize.x, 0, 0);
        }
        Vector3 RightBottom = LeftBottom + new Vector3(whipAttackSize.x, 0,0);
        Vector3 LeftTop     = LeftBottom + new Vector3(0, whipAttackSize.y, 0);
        Vector3 RightTop    = LeftBottom + new Vector3(whipAttackSize.x, whipAttackSize.y, 0);
        DrawDebugRectangle (LeftBottom, RightBottom, LeftTop, RightTop, Color.red, 1);
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
