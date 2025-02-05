using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalckholeController : MonoBehaviour
{
    [SerializeField] Transform teleportationDestination;

    private void OnTriggerEnter(Collider obj){

        obj.transform.position = teleportationDestination.position + Random.onUnitSphere * 50;

    }
}
