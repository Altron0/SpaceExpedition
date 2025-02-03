using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Joystick
    [SerializeField] JoystickController left;
    [SerializeField] JoystickController right;

    //speed
    [SerializeField, Range(0, 1)] float speed;
    [SerializeField, Range(0, 100)] float speedRotation;
    [SerializeField, Range(0, 100)] float speedUp;
    [SerializeField, Range(0, 1000)] float speedAsteroid;

    //Time
    [SerializeField] float time;
    float _timeLeft;

    //On or Off SpawnObject
    [SerializeField] bool continueSpawn;

    //Rigidbody
    [SerializeField] Rigidbody cube;

    //GameObject
    [SerializeField] GameObject asteroid;
    [SerializeField] GameObject keepGameObject;

    IEnumerator StartRandomSpawnAsteroid(float _time)
    {
        while (continueSpawn)
        {
            for (int i = 0; i < 6; i++)
            {
                yield return new WaitForSeconds(_time);

                GameObject asteroids = Instantiate(asteroid, UnityEngine.Random.onUnitSphere * 2500f, Quaternion.identity);
                asteroids.transform.parent = keepGameObject.transform;

                asteroids.transform.TryGetComponent(out Rigidbody asteroidBody);
                asteroidBody.velocity = UnityEngine.Random.onUnitSphere * speedAsteroid;
            }
        }
    }

    void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartRandomSpawnAsteroid(_timeLeft));

    }
    void Update()
    {
        MoveAbdRotateCube();
    }

    void FixedUpdate()
    {

    }

    public void MoveAbdRotateCube()
    {
        Vector3 moveVector = (cube.transform.right * left.localPositionEnd.x) +
                        (cube.transform.up * right.localPositionEnd.y) +
                        (cube.transform.forward * left.localPositionEnd.y);

        cube.position += moveVector * speed;

        cube.transform.Rotate(Vector3.up * right.localPositionEnd.x / speedRotation);
    }

}
