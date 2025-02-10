using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StationController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject _Win;
    [SerializeField] GameObject closePlayGrount;
    void Start(){
        gameObject.transform.position = UnityEngine.Random.onUnitSphere * 2500f;
        player.transform.position = -(gameObject.transform.position);
    }

    void OnTriggerEnter(Collider obj){
        if(obj.tag == "Player")
        {
            _Win.SetActive(true);
            closePlayGrount.SetActive(false);
        }
    }
}
