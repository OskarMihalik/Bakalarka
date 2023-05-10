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
            if (toggleEvents)
                TogglingOn();
            else
            {
                ToggleOn.gameObject.SetActive(true);
                ToggleOff.gameObject.SetActive(false);
            }
        }
        else
        {
            if (toggleEvents)
                TogglingOff();
            else
            {
                ToggleOn.gameObject.SetActive(false);
                ToggleOff.gameObject.SetActive(true);
            }
        }
    }

    public void Toggle()
    {
        Toggle(!Toggled);
    }
}