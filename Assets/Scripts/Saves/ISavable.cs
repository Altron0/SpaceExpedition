using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISavable : MonoBehaviour
{
    public SavableClass getRPS()
    {
        SavableClass Me = new SavableClass();
        Me.name = gameObject.name;
        Me.position = transform.position;
        Me.scale = transform.localScale;
        Me.rotation = transform.localRotation;
        return Me;
    }

    public void setRPS(SavableClass Me)
    {
        transform.rotation = Me.rotation;
        transform.position = Me.position;
        transform.localScale = Me.scale;
    }
}
