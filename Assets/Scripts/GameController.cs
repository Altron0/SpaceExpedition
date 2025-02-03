using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Move cube OSI
/// </summary>
public class GameController : MonoBehaviour
{
    //Joysticks & Character controll
    [SerializeField] JoystickController left;
    [SerializeField] JoystickController right;
    [SerializeField, Range(0, 1f)] float speed;
    [SerializeField, Range(0, 100f)] float rotationSpeed;
    [SerializeField, Range(0, 100f)] float verticalSpeed;

    [SerializeField] Text text;
    int counter;

    //Asteroids
    [SerializeField] GameObject asteroid_prefab;
    [SerializeField] Transform asteroidKeeper;
    [SerializeField, Range(0, 2500f)] float directionZone;
    [SerializeField, Range(0, 1000f)] float asteroidsSpawnDelay;
    [SerializeField] bool continueSpawningAsteroids = true;

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
    }

    void Update() 
    {
        MoveCharacter();
        text.text = (counter++).ToString();
    }

    void FixedUpdate()
    {
    }
    void MoveCharacter()
    {
        Vector3 moveVector = (cube.transform.right * left.localPositionEnd.x) +
        (cube.transform.up * right.localPositionEnd.y) +
        (cube.transform.forward * left.localPositionEnd.y);

        cube.transform.Rotate(Vector3.up * right.localPositionEnd.x / rotationSpeed);
        cube.velocity += moveVector * speed;
    }

    IEnumerator SpawnAndLaunchAsteroids(){
        GameObject asteroid;
        Vector3 randomSphere;
        while (continueSpawningAsteroids)
        {

            for(int i = 0; i < 10; i++) {
                asteroid = Instantiate(asteroid_prefab, Random.onUnitSphere * 2500, Quaternion.identity);

                asteroid.transform.parent = asteroidKeeper;
                asteroid.TryGetComponent(out Rigidbody rb);

                randomSphere = Random.insideUnitSphere;
                asteroid.transform.Rotate(randomSphere*directionZone);

                rb.velocity = asteroid.transform.forward * 100;
                //asteroidKeeper.childCount
            }
            yield return new WaitForSeconds(asteroidsSpawnDelay);

        }

    }

}
