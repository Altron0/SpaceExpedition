using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillingBar : MonoBehaviour
{
    [SerializeField] Button filling;
    [SerializeField] BarController barControler;

    private void OnTriggerEnter(Collider other)
    {
        filling.gameObject.SetActive(true);
        filling.onClick.AddListener(OnClickFillingResourses);
    }

    private void OnTriggerExit(Collider other)
    {
        filling.gameObject.SetActive(false);
    }

    void OnClickFillingResourses()
    {
        filling.gameObject.SetActive(false);
        barControler.FillOut = 12;
        Destroy(gameObject);
    }
}
