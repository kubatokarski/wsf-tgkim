using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpExp : MonoBehaviour
{
    [SerializeField] int expAmount;
    Character c;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        c = collision.GetComponent<Character>();

        if (c)
        {
            c.addExperience(expAmount);
            Destroy(gameObject);
        }
    }
}
