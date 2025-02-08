using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            if (value.Length == length)
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
            if (value.Length == length)
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

        string[] sorted_entries = new string[10];
        //перебор каждого элемента массива не начиная с нуля, а с int a
        int kl = 0;
        int a = 0;

        //предназначены чтлбы поменять элементы местами
        int copyElement;
        string copyName;
        for (int i = 0; i < 10; i++)
        {
            for (kl = a; kl < 10; kl++)
            {
                if (_points[i] < _points[kl])
                {
                    //меняем элементы массива(очки и имя)
                    copyElement = _points[i];
                    copyName = _names[i];

                    _points[i] = _points[kl];
                    _names[i] = _names[kl];

                    _names[kl] = copyName;
                    _points[kl] = copyElement;
                }
            }
            a++;
        }

        int counter = 0;
        foreach (string entry in sorted_entries)
        {
            sorted_entries[counter] = _names[counter] + ": " + _points[counter];
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
