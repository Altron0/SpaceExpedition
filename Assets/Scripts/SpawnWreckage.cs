using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnWreckage : MonoBehaviour
{
    [SerializeField, Range(0f, 10000f)] float couldSpawnJunk;

    [SerializeField] GameObject[] junk;
    System.Random randomComponent = new System.Random();

    void Start(){
        SpawnRandomJunk();
    }

    void SpawnRandomJunk(){

        for(int i = 0 ;i < couldSpawnJunk;i++) {
            GameObject junk1 = Instantiate(
                    (GameObject) junk.GetValue(randomComponent.Next(1, 5)),
                    UnityEngine.Random.insideUnitSphere * 2500f, Quaternion.identity);
            junk1.AddComponent<Rigidbody>();

            junk1.transform.parent = gameObject.transform;
        }
    }
}
