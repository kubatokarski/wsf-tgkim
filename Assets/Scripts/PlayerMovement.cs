using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    [SerializeField] GameObject weapon;
    private Vector2 movementVector;
    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;

    // Update is called once per frame
    void Update()
    {
        // Input
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if( movementVector.x != 0 ) {
            lastHorizontalVector = movementVector.x;
        }
        if( movementVector.y != 0 ) {
            lastVerticalVector = movementVector.y;
        }
    }

    // Default: 50 fps
    void FixedUpdate ()
    {
        // Movement
        rb.MovePosition(rb.position + movementVector * moveSpeed * Time.fixedDeltaTime);
        
        // TODO: change temp to something meaningful
        float temp = Input.GetAxisRaw("Horizontal");
        
        Vector3 rotateWeapon;
        if (temp < 0) {
            rotateWeapon = new Vector3(0f, 180f, 0f); 
            weapon.transform.eulerAngles = rotateWeapon;
        } else if (temp >0) {
            rotateWeapon = new Vector3(0f, 0f, 0f); 
            weapon.transform.eulerAngles = rotateWeapon;
        }
    }
    
}