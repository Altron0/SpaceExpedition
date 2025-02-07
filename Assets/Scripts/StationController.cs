using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Start(){
        gameObject.transform.position = UnityEngine.Random.onUnitSphere * 2500f;
        player.transform.position = -(gameObject.transform.position);

    }
}
