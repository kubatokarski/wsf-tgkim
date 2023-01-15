using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealth : MonoBehaviour
{
    [SerializeField] int healAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character c = collision.GetComponent<Character>();

        if(c)
        {
            Health playerHealth = c.GetComponent<Health>();
            playerHealth.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
