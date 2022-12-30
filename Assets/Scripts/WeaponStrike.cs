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
    //Vector2 whipAttackSize = new Vector2(1.8f, 1f);
    Vector2 whipAttackSize = new Vector2(1.8f, 0.5f);
    Vector2 whipAttackSizeModifier = new Vector2(0.9f, 0.95f);
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
        Vector2 WhipAttackPosition; 

        GameObject ActiveWhipAttack;
        Collider2D[] colliders;

        WhipAttackPosition = WhipAttackR.transform.position;
        if( playerMovement.lastHorizontalVector > 0) {
            ActiveWhipAttack = WhipAttackR;
        } else {
            ActiveWhipAttack = WhipAttackL;
            WhipAttackPosition = WhipAttackL.transform.position - new Vector3((ActiveWhipAttack.GetComponent<SpriteRenderer>().bounds.max - ActiveWhipAttack.GetComponent<SpriteRenderer>().bounds.min).x, 0, 0) * whipAttackSizeModifier.x ;
        }
        ActiveWhipAttack.SetActive(true);
     
        DrawDebugRectangle (WhipAttackPosition,
                            new Vector3(WhipAttackPosition.x, WhipAttackPosition.y, 0) + new Vector3(1.8f, 0, 0),
                            new Vector3(WhipAttackPosition.x, WhipAttackPosition.y, 0) + new Vector3(0, 0.8f, 0),
                            new Vector3(WhipAttackPosition.x, WhipAttackPosition.y, 0) + new Vector3(1.8f, 0.8f, 0),
                            Color.red, 1);

        colliders = Physics2D.OverlapBoxAll(WhipAttackPosition, new Vector2(1.8f, 0.8f), 0f);
        Debug.Log(ActiveWhipAttack);

        ApplyDamage(colliders);
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
