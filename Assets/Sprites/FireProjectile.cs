using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    private Vector3 direction;
    private float speed = 0.01f;
    

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        this.transform.position += direction * 0.05f;
        //this.transform.position += new Vector3(0.05f, 0.05f);
    }

    public void setDirection (Vector3 v)
    {
        direction = v;
    }
}