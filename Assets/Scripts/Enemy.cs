using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    [SerializeField] float speed;
    GameObject targetGameObject;
    Character targetCharacter;
    Rigidbody2D rb;
    [SerializeField] int hp = 1;
    [SerializeField] int damage = 1;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetGameObject = targetDestination.gameObject;
        speed = UnityEngine.Random.Range(0.3f, 1.2f);
    }

    private void FixedUpdate() 
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
        if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(damage);
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