using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    [SerializeField] float speed;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void  FixedUpdate() 
    {
        Vector2 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    void OnCollisionStay2D(Collision2D collision)
    {    
        if(collision.gameObject.GetComponent<Character>()) {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attacking player!");
    }
}