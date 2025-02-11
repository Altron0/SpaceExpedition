using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

using Palmmedia.ReportGenerator.Core.Common;
using System.Text.Json;

class StudyFileSystem : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] GameOver_Controller gameOver_Controller;
    [SerializeField] ResoursesConnector resoursesConnector;

    string path = "D:\\Unity Labs\\SpaceExpedition-Python\\Assets\\Save\\save.json";    
    string path1 = "save.json";

    void Save() 
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
           
            //Save file Unity
        }

    }
}

