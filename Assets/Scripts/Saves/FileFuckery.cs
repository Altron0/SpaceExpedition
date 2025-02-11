using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class FileFuckery : MonoBehaviour
{
    public string path;

    List<SavableClass> objList = new List<SavableClass>();

    void Start()
    {
        path = Path.GetFullPath("./") + "Save";
        if (ContinueButtonSave.buttonPressed)
            ParseFromJSON();
    }


    void ParseToJSON()
    {
        string json = "";

        foreach (ISavable obj in GetComponentsInChildren<ISavable>()) 
        {
            SavableClass sv = obj.getRPS();
            objList.Add(sv);
        }

        json = JsonHelper.ToJson<SavableClass>(objList.ToArray());

        SaveFile("InfObject.json", json);
    }

    void ParseFromJSON(){
        string data = LoadFile("InfObject.json");

        List<SavableClass> obj = JsonHelper.FromJson<SavableClass>(data).ToList();
        int counter = 0;

        foreach (ISavable objISavable in GetComponentsInChildren<ISavable>()) 
        {
            objISavable.setRPS(obj[counter]);
            counter++;
        }
        
    }

    void SaveFile(string fileName, string informationAboutObj)
    {
        StreamWriter sw = new StreamWriter(path + "/" + fileName);
        sw.Write(informationAboutObj);
        sw.Close();
    }

    string LoadFile(string fileName) 
    {
        StreamReader sr = new StreamReader(path + "/" + fileName);
        string data = sr.ReadLine();
        sr.Close();

        return data;
    }

}

/*
[Serializable]
public class SavableGameData{
    public List<SavableClass> obj = new List<SavableClass>();
}*/

[Serializable] 
public class SavableClass 
{
    public string name;

    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public void ShowInformation() 
    {
        Console.WriteLine("Name: "+ name + ", Position: " + position + ", Scale: " + scale + ", Rotation: " + rotation);
    }
}


public static class JsonHelper
{
    public static string ToJson<T>(T[] array)
    {
        List<T> wrapper = new List<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }


    public static T[] FromJson<T>(string json)
    {
        List<T> wrapper = JsonUtility.FromJson<List<T>>(json);
        return wrapper.Items;
    }


    [Serializable]
    private class List<T>
    {
        public T[] Items;
    }
}