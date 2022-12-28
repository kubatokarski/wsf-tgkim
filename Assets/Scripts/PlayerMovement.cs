using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    
    public Rigidbody2D rb;

    [SerializeField]
    GameObject weapon;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // Default: 50 fps
    void FixedUpdate ()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Debug.Log(Input.GetAxisRaw("Horizontal"));

        float temp = Input.GetAxisRaw("Horizontal");
        
        Vector3 rotateWeapon;
        if (temp < 0) {
            Debug.Log("Weapon Left");
            rotateWeapon = new Vector3(0f, 180f, 0f); 
            weapon.transform.eulerAngles = rotateWeapon;
        } else if (temp >0) {
            rotateWeapon = new Vector3(0f, 0f, 0f); 
            Debug.Log("Weapon Right");
            weapon.transform.eulerAngles = rotateWeapon;
        }
    }
    
}