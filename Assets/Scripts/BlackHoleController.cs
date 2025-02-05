using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour
{
    [SerializeField] GameObject blackHole;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = blackHole.transform.position + Random.insideUnitSphere * 200f;
    }
}
