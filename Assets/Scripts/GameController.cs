using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Move cube OSI
/// </summary>
public class GameController : MonoBehaviour
{
    //Joysticks & Character control
    [SerializeField] JoystickController left;
    [SerializeField] JoystickController right;
    [SerializeField, Range(0, 1f)] float speed;
    [SerializeField, Range(0, 100f)] float rotationSpeed;
    [SerializeField, Range(0, 100f)] float verticalSpeed;

    /*Bars*/
    [SerializeField] Bar_Controller oxygenBar;
    [SerializeField] Bar_Controller fuelBar;
    [SerializeField] bool continueUsingOxygen = true;
    float Fuel = 1f;

    //Asteroids
    [SerializeField] GameObject asteroid_prefab;
    [SerializeField] Transform asteroidKeeper;
    [SerializeField, Range(0, 2500f)] float directionZone;
    [SerializeField, Range(0, 1000f)] float asteroidsSpawnDelay;
    [SerializeField] bool continueSpawningAsteroids = true;
    int countAsteroids;

    //Game
    [SerializeField] Rigidbody cube;


    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector3.zero, 2500f);
        Gizmos.DrawWireSphere(Vector3.zero, directionZone);
    }


    void Start()
    {
        StartCoroutine(SpawnAndLaunchAsteroids());
        StartCoroutine(UseOxygen());

    }

    void Update()
    {
        MoveCharacter();
        ConsumptionFuel();
    }

    void FixedUpdate()
    {

    }

    void MoveCharacter()
    {
        Vector3 moveVector = (cube.transform.right * left.localPositionEnd.x) +
        ((cube.transform.up * right.localPositionEnd.y / 100f) * verticalSpeed) +
        (cube.transform.forward * left.localPositionEnd.y);

        cube.transform.Rotate((Vector3.up * right.localPositionEnd.x / 100) * rotationSpeed);

        cube.velocity += moveVector * speed;
    }


    //rr.gg.bb.aa
    //af.cd.13.08
    //bc.db.ab


    IEnumerator SpawnAndLaunchAsteroids() {

        GameObject asteroid;
        Vector3 randomSphere;

        while (continueSpawningAsteroids)
        {

            for (int i = 0; i < 1; i++) {
                asteroid = Instantiate(asteroid_prefab, Random.onUnitSphere * 2500, Quaternion.identity);

                asteroid.transform.parent = asteroidKeeper;
                asteroid.TryGetComponent(out Rigidbody rb);

                randomSphere = Random.insideUnitSphere;
                asteroid.transform.Rotate(randomSphere * directionZone);

                rb.velocity = asteroid.transform.forward * 100;

            }

            yield return new WaitForSeconds(asteroidsSpawnDelay);

        }

    }


    void UseFuel()
    {
        fuelBar.visibleCell -= 1;
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


    IEnumerator UseOxygen() {
        while (continueUsingOxygen) {
            yield return new WaitForSeconds(12);
            oxygenBar.visibleCell -= 1;
        }
    }

}
