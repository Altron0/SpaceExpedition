using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UFO_Zone_Controller : MonoBehaviour
{
    [SerializeField] float zoneRadius;
    [SerializeField] bool keepSelectingTargets = true;
    [SerializeField] bool playerFound = false;
    Transform player;

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, zoneRadius);
    }

    void Start()
    {
        StartCoroutine(UFOTargetSelect());
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            player = collider.transform;
            playerFound = true;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player")
            playerFound = false;
    }


    IEnumerator UFOTargetSelect()
    {
        Vector3 target = transform.position;

        float speed = 1;

        while(keepSelectingTargets)
        {
            if(playerFound)
            {
                target = player.position;
                speed = 5;
            }
            else
            {
                speed = 1;
            }
            foreach (UFOController UFO in transform.GetComponentsInChildren<UFOController>())
            {
                if(!playerFound)
                    target = UnityEngine.Random.insideUnitSphere * zoneRadius + transform.position;
                UFO.target = target;
                UFO.speed = speed;
            }
            yield return new WaitForSeconds( (0.5f) * Convert.ToSingle(playerFound) + (2f) * Convert.ToSingle(!playerFound));
        }
    }
}
