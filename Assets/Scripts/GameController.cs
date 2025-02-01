using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Move cube OSI
/// </summary>
public class GameController : MonoBehaviour
{
    [SerializeField] JoystickController left;
    [SerializeField] JoystickController right;
    [SerializeField] Rigidbody cube;
    [SerializeField, Range(0, 1)] float mul;
    [SerializeField, Range(0, 100)] float mulVectorRotate;
    [SerializeField, Range(0, 100)] float mulVectorUp;
    Vector3 moveVector;


    void Start()
    {

    }
    void Update() 
    {
        Vector3 moveVector = (cube.transform.right * left.localPositionEnd.x) +
                        (cube.transform.up * right.localPositionEnd.y) +
                        (cube.transform.forward * left.localPositionEnd.y);
    }
    void FixedUpdate()
    {
        cube.transform.Rotate(Vector3.up * right.localPositionEnd.x / mulVectorRotate);
        cube.position += moveVector * mul;
    }
}
