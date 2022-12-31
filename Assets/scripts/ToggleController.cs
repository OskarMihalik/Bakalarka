using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleController : MonoBehaviour
{
    [SerializeField] private Transform ToggleOn;
    [SerializeField] private Transform ToggleOff;
    public bool Toggled { get; private set; }

    public UnityEvent onToggleOn;
    public UnityEvent onToggleOff;

    public void TogglingOn()
    {
        onToggleOn.Invoke();
        Toggled = true;
    }

    public void TogglingOff()
    {
        onToggleOff.Invoke();
        Toggled = false;
    }

    public void Toggle(bool toggle)
    {
        if (toggle)
        {
            ToggleOn.gameObject.SetActive(true);
            ToggleOff.gameObject.SetActive(false);
            TogglingOn();
        }
        else
        {
            ToggleOn.gameObject.SetActive(false);
            ToggleOff.gameObject.SetActive(true);
            TogglingOff();
        }
    }

    public void Toggle()
    {
        Toggle(!Toggled);
    }
}