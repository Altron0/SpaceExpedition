using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Move cube OSI
/// </summary>
public class GameController : MonoBehaviour
{
    //Character control
    [SerializeField] JoystickController left;
    [SerializeField] JoystickController right;

    [SerializeField, Range(0, 1f)] float speed;
    [SerializeField, Range(0, 100f)] float afterburnerSpeed;
    [SerializeField, Range(0, 100f)] float rotationSpeed;
    [SerializeField, Range(0, 100f)] float verticalSpeed;

    /*Bars*/
    [SerializeField] public Bar_Controller oxygenBar;
    [SerializeField] public Bar_Controller fuelBar;
    [SerializeField] bool continueUsingOxygen = true;
    float Fuel = 1f;

    //Asteroids
    [SerializeField] GameObject asteroid_prefab;
    [SerializeField] Transform asteroidKeeper;
    [SerializeField, Range(0, 2500f)] float asteroidSpawnZone;
    [SerializeField, Range(0, 1000f)] float asteroidsSpawnDelay;
    [SerializeField] bool continueSpawningAsteroids = true;
    int countAsteroids;

    //Game
    [SerializeField] Rigidbody cube;


    //Afterburner button
    [SerializeField] Button afterburnerButton;
    bool afterburnerButtonPressed;

    [SerializeField] GameOver_Controller GameOverController;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector3.zero, 2500f);
        Gizmos.DrawWireSphere(Vector3.zero, asteroidSpawnZone);

    }

    void Start()
    {
        StartCoroutine(SpawnAndLaunchAsteroids());
        StartCoroutine(UseOxygen());
        afterburnerButton.onClick.AddListener(AfterburnerButtonPress);
    }

    void Update()
    {
        MoveCharacter();
        SpendFuel();
    }

    void AfterburnerButtonPress()
    {
        afterburnerButtonPressed = !afterburnerButtonPressed;
    }

    void FixedUpdate()
    {

    }

    void MoveCharacter()
    {
        Vector3 moveVelocity = speed * ((cube.transform.right * left.localPositionEnd.x) +
        (cube.transform.up * right.localPositionEnd.y) +
        (cube.transform.forward * left.localPositionEnd.y));


        Vector3 afterburnerVelocity = Convert.ToInt32(afterburnerButtonPressed) * afterburnerSpeed * moveVelocity.normalized;

        cube.angularVelocity += Vector3.up * right.localPositionEnd.x / rotationSpeed;

        cube.velocity += moveVelocity + afterburnerVelocity;
    }

    IEnumerator SpawnAndLaunchAsteroids()
    {

        GameObject asteroid;
        Vector3 randomSphere;

        while (continueSpawningAsteroids)
        {

            for(int i = 0; i < 1; i++) {
                asteroid = Instantiate(asteroid_prefab, UnityEngine.Random.onUnitSphere * 2500, Quaternion.identity);

                asteroid.transform.parent = asteroidKeeper;
                asteroid.TryGetComponent(out Rigidbody rb);

                randomSphere = UnityEngine.Random.insideUnitSphere;
                asteroid.transform.Rotate(randomSphere * asteroidSpawnZone);

                rb.velocity = asteroid.transform.forward * 100f;

            }

            yield return new WaitForSeconds(asteroidsSpawnDelay);

        }

    }

    void SpendFuel()
    {
        if(right.localPositionEnd != Vector2.zero || left.localPositionEnd != Vector2.zero){
            Fuel -= 0.002f + Convert.ToInt32(afterburnerButtonPressed) / 100;

            if(Fuel <= 0){
                UseFuel();
                Fuel = 1;
            }
        }
    }

    void UseFuel()
    {
        fuelBar.visibleCell -= 1;
        if(fuelBar.visibleCell == 0)
            Application.Quit();
    }

    void ConsumptionFuel()
    {
        if (right.localPositionEnd != Vector2.zero || left.localPositionEnd != Vector2.zero) 
        {
            Fuel -= 0.001f;

            if(Fuel <= 0)
            {
                UseFuel();
                Fuel = 1f;
            }
        }
    }

    IEnumerator UseOxygen()
    {
        while (continueUsingOxygen) {
            yield return new WaitForSeconds(12f);
            oxygenBar.visibleCell -= 1;
        }
    }
}
