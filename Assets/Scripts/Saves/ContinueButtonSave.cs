using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButtonSave : MonoBehaviour
{
    [SerializeField] Button con;
    public static bool buttonPressed = false;

    void Update()
    {
        con.onClick.AddListener(checkButtonPressed);
    }

    void checkButtonPressed() 
    {
        buttonPressed = true;
    }
}
