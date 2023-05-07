using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 1f;    
    [SerializeField] private MeteoriteDetailsSO meteoriteDetails;
    private Vector3 moveDirectionVector;
    
    private void Start()
    {
        moveDirectionVector = new Vector3(0, 0, -1);
    }

    private void Update()
    {
        SpawnMeteor();
    }

    private void SpawnMeteor()
    {
        // Start Spawning
        StartCoroutine(SpawnMeteorRoutine(meteoriteDetails, moveDirectionVector));
    }

    private IEnumerator SpawnMeteorRoutine(MeteoriteDetailsSO meteoriteDetails, Vector3 moveDirectionVector)
    {
        GameObject meteoritePrefab = meteoriteDetails.meteorPrefab;

        // Get random speed value
        float meteorSpeed = Random.Range(meteoriteDetails.minSpeed, meteoriteDetails.maxSpeed);

        yield return new WaitForSeconds(spawnInterval);
        // Get Gameobject with IFireable component
        IFireable meteor = (IFireable)PoolManager.Instance.ReuseComponent(meteoritePrefab, meteoritePrefab.transform.position, Quaternion.identity);
        
        // Initialise Ammo
        meteor.InitialiseMeteorite(meteoriteDetails, meteorSpeed, moveDirectionVector); 
        yield return new WaitForSeconds(spawnInterval);
    
    }
}
