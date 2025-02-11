using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileFuckery : MonoBehaviour
{
    public string path;
    void Start()
    {
        path = Path.GetFullPath("./") + "Save";
        List<SavableClass> objd = new List<SavableClass>();

        foreach(ISavable obj in GetComponentsInChildren<ISavable>())
        {
            SavableClass sv = obj.getRPS();
            objd.Add(sv);
        }
        string json = JsonUtility.ToJson(objd);

        SaveFile("data.json", json);
    }


    string ParseToJSON(){
        return "";
    }

    SavableClass ParseFromJSON(){
        return new SavableClass();
    }

    void SaveFile(string fileName, string data){
        StreamWriter sw = new StreamWriter(path + "/" + fileName);
        sw.Write(data);
        sw.Close();
    }

    string LoadFile(string fileName) {
        StreamReader sr = new StreamReader(path + "/" + fileName);
        string data = sr.ReadLine();
        sr.Close();

        return data;
    }

}/*
[Serializable]
public class SavableGameData{
    public List<SavableClass> obj = new List<SavableClass>();
}*/
[Serializable]
public class SavableClass {
    public string name;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
}