using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FillingResourses : MonoBehaviour
{
    [SerializeField] Bar_Controller Bar;
    [SerializeField] Button Filling;

    void OnTriggerEnter(Collider obj){
        Filling.gameObject.SetActive(true);
        Filling.onClick.AddListener(FillResource);
    }

    void FillResource()
    {
        Bar.visibleCell = 12;
        Destroy(gameObject);
    }

    void OnTriggerExit(Collider obj){
        Filling.gameObject.SetActive(false);
        Filling.onClick.RemoveListener(FillResource);
    }

}
