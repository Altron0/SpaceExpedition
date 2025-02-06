using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityEditor;

public class BalckholeController : MonoBehaviour
{
    [SerializeField] Transform teleportationDestination;

    private void OnTriggerEnter(Collider obj){

        if(obj.tag != "Blackhole")
        {
            obj.transform.position = (teleportationDestination.position + UnityEngine.Random.onUnitSphere * 10 * obj.transform.localScale.magnitude);
        }
    }
}
