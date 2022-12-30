using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    float timeToDisable = 0.3f;
    float timer;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        timer = timeToDisable;
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0f) 
        {
            gameObject.SetActive(false);
        }
    }
}
