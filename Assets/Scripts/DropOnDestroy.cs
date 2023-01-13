using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject healthPickup;
    [SerializeField] [Range(0f, 1f)] float chanceToSpawn = 1f;

    private void OnDestroy()
    {
        if(Random.value < chanceToSpawn)
        {
            Transform t = Instantiate(healthPickup).transform;
            t.position = transform.position;
        }
    }
}
