using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeteorDetails_", menuName = "Scriptable Objects/Meteors/Meteor Details")]
public class MeteoriteDetailsSO : ScriptableObject
{
    [Space(10)]
    public GameObject meteorPrefab;
    [Space(10)]
    public float minSpeed;
    public float maxSpeed;
    [Space(10)]
    public float minScale;
    public float maxScale;
    [Space(10)]
    public float minPositionX;
    public float maxPositionX;
    [Space(10)]
    public float minPositionY;
    public float maxPositionY;
    [Space(10)]
    public float minPositionZ;
    public float maxPositionZ;
    [Space(10)]
    public float minRotationX;
    public float maxRotationX;
    [Space(10)]
    public float minRotationY;
    public float maxRotationY;
    [Space(10)]
    public float minRotationZ;
    public float maxRotationZ;
}
