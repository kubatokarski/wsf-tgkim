using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private float fireProjectileInterval = 1;
    private GameObject playerCharacter;
    [SerializeField] private GameObject fireProjectile;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( spawnProjectile( fireProjectileInterval, new Vector3(0f, 0f), new Vector3 (1f, 1f)) );
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnProjectile( float interval, Vector3 spawnPosition, Vector3 direction )
    {
        yield return new WaitForSeconds(interval);
        Debug.Log("spawning projectile");
        GameObject newProjectile = Instantiate(fireProjectile, playerCharacter.transform.position, Quaternion.identity);
        newProjectile.transform.parent = this.transform;

        StartCoroutine( spawnProjectile(interval, spawnPosition, direction) );
    }
}
