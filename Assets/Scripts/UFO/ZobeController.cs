using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ZobeController : MonoBehaviour
{
    [SerializeField] UFOController UFO;
    bool playFound = false;

    GameObject playerGame;

    private void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
            playFound = true;
        playerGame = player.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        playFound = false;
    }

    private void Start()
    {
        StartCoroutine(directionUFO());
    }

    IEnumerator directionUFO()
    {
        while (true)
        {
            if (playFound)
            {
                UFO.target = playerGame.transform.position;
                yield return new WaitForSeconds(1f);
            }
            else 
            {
                UFO.target = gameObject.transform.position + (Random.insideUnitSphere * 500f);
                yield return new WaitForSeconds(2);
            }
        }
    }

}
