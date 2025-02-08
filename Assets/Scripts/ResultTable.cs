using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTable : MonoBehaviour
{
    [SerializeField] string[] _names;
    [SerializeField] int[] _points;
    const int length = 10;

    public string[] names
    {
        get
        {
            return _names;
        }
        set
        {
            if(value.Length == length)
            {
                _names = value;
            }
            UpdateText();
        }
    }
    public int[] points
    {
        get
        {
            return _points;
        }
        set
        {
            if(value.Length == length)
            {
                _points = value;
            }
            UpdateText();
        }
    }

    void Start()
    {
        UpdateText();
    }

    void UpdateText()
    {
        int[] positions = new int[10]{9,8,7,6,5,4,3,2,1,0};
        string[] sorted_entries = new string[10];



        int counter = 0;
        foreach (string entry in sorted_entries)
        {
            sorted_entries[counter] = _names[positions[counter]] + ": " + _points[positions[counter]];
            counter++;
        }

        counter = 0;
        foreach (Text entry in transform.GetComponentsInChildren<Text>())
        {
            entry.text = sorted_entries[counter];
            counter++;
        }
    }
}
