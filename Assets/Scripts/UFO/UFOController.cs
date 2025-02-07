using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public Vector3 target;

    [SerializeField, Range(1f, 100f)] float speedUFO;

    private void Update()
    {
        moveUFO();
    }    

    void moveUFO()
    {
        gameObject.transform.TryGetComponent(out Rigidbody ufo);
        ufo.velocity = (target - transform.position) * speedUFO;
    }
}
