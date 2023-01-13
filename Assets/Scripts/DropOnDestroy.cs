using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject healthPickup;
    [SerializeField] [Range(0f, 1f)] float chanceToSpawn = 1f;

    private bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;        
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            if(Random.value < chanceToSpawn)
            {
                //Transform t = Instantiate(healthPickup).transform;
                //t.position = transform.position;
                GameObject newPickup = Instantiate(healthPickup);
                newPickup.transform.position = transform.position;

            }
        }
    }
}
