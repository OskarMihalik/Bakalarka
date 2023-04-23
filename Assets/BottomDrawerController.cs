using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BottomDrawerController : MonoBehaviour
{
    // rectTransform.offsetMin = new Vector2(value, rectTransform.offsetMin.y);
    public float maxHeight;
    private RectTransform rectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void ChangeDrawerHeight()
    {
        
    }
}