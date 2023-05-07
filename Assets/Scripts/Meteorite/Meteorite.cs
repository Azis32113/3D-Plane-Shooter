using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour, IFireable
{
    private MeteoriteDetailsSO meteoriteDetails;
    private float meteorRange;
    private float meteorSpeed;
    private Vector3 moveDirectionVector;

    private void Update()
    {
        // Calculate distance vector to move ammo
        Vector3 distanceVector = moveDirectionVector * meteorSpeed * Time.deltaTime;
        
        // Disable after max range reached
        meteorRange -= distanceVector.magnitude;

        if (meteorRange < 0f)
        {
            DisableMeteor();
        }

    }

    public void InitialiseMeteorite(MeteoriteDetailsSO meteoriteDetails, float meteorSpeed, Vector3 moveDirectionVector)
    {
        SetDirection(meteoriteDetails);

        meteorRange = meteoriteDetails.meteorRange;

        this.meteorSpeed = meteorSpeed;

        this.moveDirectionVector = moveDirectionVector;

        // Activate Meteor gameobject
        gameObject.SetActive(true);
    }

    private void SetDirection(MeteoriteDetailsSO meteoriteDetails)
    {
        
        // calculate random spread angle between min and max
        float randomPositionX = Random.Range(meteoriteDetails.minPositionX, meteoriteDetails.maxPositionX);

        // calculate random spread angle between min and max
        float randomPositionY = Random.Range(meteoriteDetails.minPositionY, meteoriteDetails.maxPositionY);
        
        // calculate random spread angle between min and max
        float randomPositionZ = Random.Range(meteoriteDetails.minPositionZ, meteoriteDetails.maxPositionZ);

        // calculate random spread angle between min and max
        float randomRotationX = Random.Range(meteoriteDetails.minRotationX, meteoriteDetails.maxRotationX);

        // calculate random spread angle between min and max
        float randomRotationY = Random.Range(meteoriteDetails.minRotationY, meteoriteDetails.maxRotationY);

        // calculate random spread angle between min and max
        float randomRotationZ = Random.Range(meteoriteDetails.minRotationZ, meteoriteDetails.maxRotationZ);

        transform.position = new Vector3(randomPositionX, randomPositionY, randomPositionZ);

        transform.eulerAngles = new Vector3(randomRotationX, randomRotationY, randomRotationZ);
    }

    private void DisableMeteor()
    {
        gameObject.SetActive(false);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
