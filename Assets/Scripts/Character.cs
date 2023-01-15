using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    private int level = 1;
    private int experience = 0;

    [SerializeField] private TextMeshProUGUI levelElement;
    [SerializeField] private TextMeshProUGUI experienceElement;


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
        //Debug.Log("Experience: " + experience);
        experienceElement.text = "EXP: " + experience;
    }

    public void CheckLevelUp()
    {
        if(experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
            //Debug.Log("Level Up! Now " + level);
            levelElement.text = "LEVEL: " + level;
            this.GetComponent<Health>().IncreaseHealth(10);
        }

    }
}
