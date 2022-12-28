using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    [SerializeField] float speed;
    GameObject targetGameObject;
    Rigidbody2D rb;
    [SerializeField] int hp = 4;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetGameObject = targetDestination.gameObject;
    }

    private void  FixedUpdate() 
    {
        Vector2 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    void OnCollisionStay2D(Collision2D collision)
    {    
        if(collision.gameObject == targetGameObject) {
            Attack();
        }
    }

    private void Attack()
    {
        //Debug.Log("Attacking player!");
    }

    public void TakeDamage (int damage) 
    {
        hp -= damage;
        
        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }
}