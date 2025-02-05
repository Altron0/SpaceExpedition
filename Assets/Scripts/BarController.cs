using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    int _FillOut = 12;

    public int FillOut 
    {
        get 
        { 
            return _FillOut; 
        }

        set 
        {
            _FillOut = value;
             
            int i = 0;

            foreach (Image img in transform.GetComponentsInChildren<Image>())
            {
                if (i < value) 
                {
                    img.color = new Color(img.color.r, img.color.g, img.color.b, 100);
                }
                else 
                {
                    img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
                }
                i++;
            }
        }
    }
}
