using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public Vector3 target;
    public float speed = 2;
    Rigidbody rb;

    void Start()
    {
        gameObject.TryGetComponent(out Rigidbody _rb);
        rb = _rb;
    }

    void Update()
    {
        rb.velocity += (target - transform.position).normalized * speed;
    }
}
