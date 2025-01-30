using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] JoystickController left;
    [SerializeField] JoystickController right;
    [SerializeField] Rigidbody cube;
    [SerializeField, Range(0, 1)] float mul;

    void Start()
    {

    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
            Vector3 moveVector =    (cube.transform.right * left.localPositionEnd.x) + 
                                    (Vector3.up * right.localPositionEnd.y) + 
                                    (cube.transform.forward * left.localPositionEnd.y);

         cube.position += moveVector*mul;

         cube.transform.Rotate(Vector3.up * right.localPositionEnd.x);

    }
}
