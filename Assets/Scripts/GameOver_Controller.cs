using UnityEngine;
using System;

public class GameOver_Controller : MonoBehaviour
{
    [SerializeField] Bar_Controller oxygenBar;
    [SerializeField] Bar_Controller fuelBar;

    [SerializeField] GameObject gameOverController;
    [SerializeField] GameObject playGrountFrame;
    [SerializeField] GameObject playGrountWindow;

    public bool buttonPressed = false;

    void Update(){
        checkBar();
        ConstructionResours();
    }

    void checkBar(){
            if(oxygenBar.visibleCell == 0 || fuelBar.visibleCell == 0) {
                gameOverController.SetActive(true);
                playGrountWindow.SetActive(false);
                playGrountFrame.SetActive(false);
                buttonPressed = true;
            }
    }

    void ConstructionResours(){
        if(buttonPressed){
            oxygenBar.visibleCell = 12;
            fuelBar.visibleCell = 12;
            buttonPressed = false;
        }
    }
}
