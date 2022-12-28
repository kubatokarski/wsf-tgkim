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
    [SerializeField] Vector2 whipAttackSize = new Vector2(2.1f, 0.7f);
    [SerializeField] int axeDamage = 1;

    private void Awake ()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        playerMovement.lastHorizontalVector = 1;
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

        if( playerMovement.lastHorizontalVector > 0) {
            WhipAttackR.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(WhipAttackR.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        } else {
            WhipAttackL.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(WhipAttackL.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
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
}
