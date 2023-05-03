using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleController : MonoBehaviour
{
    [SerializeField] private Transform ToggleOn;
    [SerializeField] private Transform ToggleOff;
    public bool Toggled;

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

    public void Toggle(bool toggle, bool toggleEvents = true)
    {
        if (toggle)
        {
            ToggleOn.gameObject.SetActive(true);
            ToggleOff.gameObject.SetActive(false);
            if (toggleEvents)
                TogglingOn();
        }
        else
        {
            ToggleOn.gameObject.SetActive(false);
            ToggleOff.gameObject.SetActive(true);
            if (toggleEvents)
                TogglingOff();
        }
    }

    public void Toggle()
    {
        Toggle(!Toggled);
    }
}