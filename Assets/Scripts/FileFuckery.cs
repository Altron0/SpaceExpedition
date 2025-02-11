using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Threading.Tasks;

public class FileFuckery : MonoBehaviour
{
    public string path = "@C:\\";
    public string nameFile = "test.txt";

    [SerializeField] InputField textField;

    void Start()
    {
        path = ReadDirectory();
    }

    void Save(string fileName, string data){
        StreamWriter sw = new StreamWriter(path + "/" + fileName, true);
        sw.Write(data);
        sw.Close();
    }

    string Load(string fileName)
    {
        StreamReader sr = new StreamReader(path + "/" + fileName);
        string data = sr.ReadLine();
        sr.Close();
        return data;
    }

    string ReadDirectory() {
        return Path.GetFullPath("./");
    }

}
