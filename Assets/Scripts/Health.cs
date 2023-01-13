using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] StatusBar hpBar;
    [SerializeField] private GameObject healthPickup;


    private int MAX_HEALTH = 40;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Heal(10);
        }

    }

    public void SetHealth(int maxHealth, int health)
    {
        //this.MAX_HEALTH = maxHealth;
        this.MAX_HEALTH = health;
        this.health = health;
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage.");
        }

        this.health -= amount;
        if(this.hpBar != null)
        {
            //this.hpBar.SetState(this.health, this.MAX_HEALTH, this.transform.localScale.x);
            this.hpBar.SetState(this.health, this.MAX_HEALTH);
        }
        StartCoroutine(VisualIndicator(Color.red));

        if(health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing.");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;
        StartCoroutine(VisualIndicator(Color.green));

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
        this.hpBar.SetState(this.health, this.MAX_HEALTH);
       }

    private void Die()
    {
        /*
        Character c = this.GetComponent<Character>();
        if(c)
        {
            // Player Character
        }
        else
        {
            // Enemy

            float healthPickupChance = 0.5f;
            float rand = Random.value;
            if(rand<healthPickupChance)
            {
                Debug.Log( rand + " health pickup! " + healthPickup);
                GameObject newPickup = Instantiate(healthPickup, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            }
            else
            {
                //Debug.Log( rand );
            }
        }*/
        Destroy(gameObject);
    }
}
