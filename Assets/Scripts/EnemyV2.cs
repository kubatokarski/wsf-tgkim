using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV2 : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private EnemyDataV2 data;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValues();
    }

    void Update()
    {
        Swarm();        
    }

    private void Swarm()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    //private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(collider.GetComponent<Health>() != null)
            {
                collider.GetComponent<Health>().Damage(damage);
                //this.GetComponent<Health>().Damage(10000);
            }
        }
    }

    private void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

}
