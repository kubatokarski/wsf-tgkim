using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int level = 1;
    private int experience = 0;

    private int TO_LEVEL_UP
    {
        get
        {
            return level * 50;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        Debug.Log("Experience: " + experience);
    }

    public void CheckLevelUp()
    {
        if(experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
            Debug.Log("Level Up! Now " + level);
        }

    }
}
