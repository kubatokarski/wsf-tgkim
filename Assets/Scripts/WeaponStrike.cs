using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStrike : MonoBehaviour
{
    float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject WhipAttackL;
    [SerializeField] GameObject WhipAttackR;

    PlayerMovement playerMovement;

    private void Awake ()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
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
        Debug.Log("Attack!");
        timer = timeToAttack;

        if( playerMovement.lastHorizontalVector > 0) {
            WhipAttackR.SetActive(true);
        } else {
            WhipAttackL.SetActive(true);
        }
    }
}
