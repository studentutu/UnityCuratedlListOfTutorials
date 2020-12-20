using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartedAutoGrab : MonoBehaviour
{
    [SerializeField] private float Second=2f;
    [SerializeField] private UnityEvent StartAutoEvent;

    private void Start()
    {
        StartCoroutine(StartAuto());
    }

    private IEnumerator StartAuto()
    {
        yield return new WaitForSeconds(Second);
        StartAutoEvent?.Invoke();
    }

}
