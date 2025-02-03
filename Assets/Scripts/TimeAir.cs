using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.Android;
using UnityEngine.UI;
using UnityEditor.Rendering;

public class TimeAir : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Image timeText;
    private float _timeLeft;

    private IEnumerator StartTime()
    {

        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            timeText.fillAmount = _timeLeft / time;
            yield return new WaitForSeconds(1);
        }
    }



    void Start()
    {
        _timeLeft = time;
        
    }

    void Update()
    {
        StartCoroutine(StartTime());
    }
}