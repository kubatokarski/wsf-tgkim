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

    LineRenderer l;

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
        //float xAttackMultiplier = 0.9f;
        //float yAttackMultiplier = 0.9f;

        timer = timeToAttack;

        if( playerMovement.lastHorizontalVector > 0) {
            WhipAttackR.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(WhipAttackR.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
            //DrawDebugLine(  new Vector3(WhipAttackR.transform.position.x, WhipAttackR.transform.position.y),
            //                new Vector3(WhipAttackR.transform.position.x + WhipAttackR.GetComponent<SpriteRenderer>().bounds.size.x * xAttackMultiplier, WhipAttackR.transform.position.y + WhipAttackR.GetComponent<SpriteRenderer>().bounds.size.y));
            //Debug.Log( "attack width: "  + (WhipAttackR.GetComponent<SpriteRenderer>().bounds.size.x * xAttackMultiplier) + 
            //           "attack height: " + (WhipAttackR.GetComponent<SpriteRenderer>().bounds.size.y * yAttackMultiplier) );
        } else {
            WhipAttackL.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(WhipAttackL.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
            //DrawDebugLine(  new Vector3(WhipAttackL.transform.position.x, WhipAttackL.transform.position.y),
            //                new Vector3(WhipAttackL.transform.position.x - WhipAttackL.GetComponent<SpriteRenderer>().bounds.size.x * xAttackMultiplier, WhipAttackL.transform.position.y + WhipAttackL.GetComponent<SpriteRenderer>().bounds.size.y));
            //Debug.Log( "attack width: "  + (WhipAttackL.GetComponent<SpriteRenderer>().bounds.size.x * xAttackMultiplier) + 
            //           "attack height: " + (WhipAttackL.GetComponent<SpriteRenderer>().bounds.size.y * yAttackMultiplier) );                    
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

    private void DrawDebugLine(Vector3 startPoint, Vector3 endPoint) {
        if (l==null) {
            l = gameObject.AddComponent<LineRenderer>();
        }
        
        List<Vector3> pos = new List<Vector3>();
        pos.Add(startPoint);
        pos.Add(endPoint);
        l.startWidth = 0.01f;
        l.endWidth = 0.01f;
        l.SetPositions(pos.ToArray());
        l.useWorldSpace = true;
    }
}
