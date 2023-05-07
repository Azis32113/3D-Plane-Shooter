using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFireable
{
    void InitialiseMeteorite(MeteoriteDetailsSO meteoriteDetails, float meteorSpeed, Vector3 moveDirectionVector);

    GameObject GetGameObject();
}
