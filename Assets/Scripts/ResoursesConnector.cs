using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResoursesConnector : MonoBehaviour
{
    [SerializeField] public Bar_Controller bar;
    [SerializeField] Button EnteractionButton;

    void Start()
    {
        RandomizePosition();
    }

    public void RandomizePosition() {
            transform.position = Random.insideUnitSphere * 2250f;
    }

    void OnTriggerEnter(Collider obj){
        EnteractionButton.gameObject.SetActive(true);
        EnteractionButton.onClick.AddListener(FillResource);
    }

    void FillResource()
    {
        bar.visibleCell = 12;
        Destroy(gameObject);
    }

    void OnTriggerExit(Collider obj){
        EnteractionButton.gameObject.SetActive(false);
        EnteractionButton.onClick.RemoveListener(FillResource);
    }

}