using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_Controller : MonoBehaviour
{
    [SerializeField] int _visibleCell = 12;

    public int visibleCell
    {
        get
        {
            return _visibleCell;
        }
        set
        {
            _visibleCell = value;
            int i = 0;

            foreach(Image img in transform.GetComponentsInChildren<Image>())
            {
                if(i < value)
                {
                    img.color = new Color(img.color.r,img.color.g,img.color.b, 100);
                }
                else
                {
                    img.color = new Color(img.color.r,img.color.g,img.color.b, 0);
                }
                i++;
            }
        }
    }
}
