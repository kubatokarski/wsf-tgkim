using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    private int counter = 0;
    private bool isMoving = false;
    private float speed = 0.05f;
    private Vector3 direction;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        //this.transform.position += direction * speed;
    }
}