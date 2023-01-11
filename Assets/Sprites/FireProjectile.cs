using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    private Vector3 direction;
    private GameObject playerCharacter;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        this.transform.position += direction * 0.05f;
    }

    public void setDirection (Vector3 v)
    {
        this.direction = v;
    }

    public void setPlayerCharacter(GameObject pc)
    {
        this.playerCharacter = pc;
    }

    private int damage = 4;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null && collider.tag != "Player")
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}