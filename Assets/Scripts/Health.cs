using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] StatusBar hpBar;
    [SerializeField] private GameObject healthPickup;
    [SerializeField] private GameTimer gameTimer;


    private int MAX_HEALTH = 40;

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    public void IncreaseHealth(int amount)
    {
        this.MAX_HEALTH += amount;
        this.health += amount;
    }

    private IEnumerator VisualIndicator(Color color, float t)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(t);
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
            this.hpBar.SetState(this.health, this.MAX_HEALTH);
        }
        StartCoroutine(VisualIndicator(Color.red, 0.2f));

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
        StartCoroutine(VisualIndicator(Color.green, 0.5f));

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
        Character c = this.GetComponent<Character>();
        if(c)
        {
            // Player Character
            gameTimer.gameOver = true;
        }

        Destroy(gameObject);
    }
}
