using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Joystick and velosity button
    [SerializeField] JoystickController left;
    [SerializeField] JoystickController right;
    [SerializeField] VelosityController buttonVelosity;

    //speed
    [SerializeField, Range(0, 1)] float speed;
    [SerializeField, Range(0, 100)] float speedRotation;
    [SerializeField, Range(0, 100)] float speedUp;
    [SerializeField, Range(0, 10000)] float speedAsteroid;

    [SerializeField, Range(0, 1000)] float speedVelosity;

    //Time
    [SerializeField] float time;
    float _timeLeft;

    //On or Off SpawnObject
    [SerializeField] bool continueSpawn;
    bool RemoveAsteroid = true;

    //Rigidbody
    [SerializeField] Rigidbody cube;

    //GameObject
    [SerializeField] GameObject asteroid;
    [SerializeField] GameObject keepGameObject;

    //Oxygen and Fuel Bar
    [SerializeField] BarController OxygenBar;
    [SerializeField] BarController FuelBar;
    float Fuel = 1f;


    //Spawn Oxygen and Fuel figure
    [SerializeField] GameObject oxygenSpawnBar;
    [SerializeField] GameObject fuelSpawnBar;
    [SerializeField] GameObject keepBerFuel;
    [SerializeField] GameObject keepBerOxygen;


    void Start()
    {
        _timeLeft = time;
        SpawnOxygenAndFuelResourses();
        StartCoroutine(UseOxygen());
        StartCoroutine(StartRandomSpawnAsteroid(_timeLeft));
    }

    void Update()
    {
        MoveAndRotateCube();
        SpendFuel();
    }

    void FixedUpdate()
    {

    }

    void UseFuel()
    {
        FuelBar.FillOut -= 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 2500f);
    }


    IEnumerator UseOxygen()
    {
        while (OxygenBar.FillOut >= 0)
        {
            yield return new WaitForSeconds(12);
            OxygenBar.FillOut -= 1;

            if (OxygenBar.FillOut == 0)
                Application.Quit();
        }
    }


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
                asteroidBody.transform.Rotate(UnityEngine.Random.insideUnitSphere * 10f);
            }

            while (RemoveAsteroid & keepGameObject.transform.childCount > 100)
            {
               for(int i = 0;i < 6; i++) 
                {
                    Destroy(keepGameObject.transform.GetChild(i));
                }
                RemoveAsteroid = false;
            }
        }
    }


    public void MoveAndRotateCube()
    {
        Vector3 moveVector = (cube.transform.right * left.localPositionEnd.x) +
                        (cube.transform.up * right.localPositionEnd.y) +
                        (cube.transform.forward * left.localPositionEnd.y);

        
        cube.transform.position += moveVector * speed + ((float) Convert.ToInt32(buttonVelosity.buttonPressed) 
            * moveVector.normalized * speedVelosity);


        cube.transform.Rotate(Vector3.up * right.localPositionEnd.x / speedRotation);
    }

    void SpendFuel() 
    {
        if (right.localPositionEnd != Vector2.zero || left.localPositionEnd != Vector2.zero)
        {
            Fuel -= 0.001f;
            if (Fuel <= 0)
            {
                UseFuel();
                Fuel = 1;
            }

            else if(FuelBar.FillOut == 0)
                Application.Quit();
        }
    }


    void SpawnOxygenAndFuelResourses() 
    {
        for (int i = 0;i < 3; i++) {
            GameObject oxygen = Instantiate(oxygenSpawnBar, UnityEngine.Random.insideUnitSphere * 2000f, Quaternion.identity);
            oxygen.transform.parent = keepBerOxygen.transform;

            GameObject fuel = Instantiate(fuelSpawnBar, UnityEngine.Random.insideUnitSphere * 2000f, Quaternion.identity);
            fuel.transform.parent = keepBerFuel.transform;
        }
    }


}
