using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BottomDrawerController : MonoBehaviour
{
    private float rectStart;

    [SerializeField] private float upPosition;

    private bool tweeningUp;
    private RectTransform rectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void ChangeDrawerHeight()
    {
        if (tweeningUp)
        {
            TweenDown();
        }
        else
        {
            TweenUp();
        }
    }
    
    private void TweenUp()
    {
        var start = rectStart;
        if (LeanTween.isTweening(gameObject))
        {
            LeanTween.cancel(gameObject);
            start = rectTransform.offsetMin.y;
        }
        LeanTween.value(gameObject, start, upPosition, .5f).setOnUpdate((value) =>
        {
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMin.x,value);
        });
        tweeningUp = true;
    }

    private void TweenDown()
    {
        var start = upPosition;
        if (LeanTween.isTweening(gameObject))
        {
            LeanTween.cancel(gameObject);
            start = rectTransform.offsetMin.y;
        }

        LeanTween.value(gameObject, start, rectStart, .5f).setOnUpdate((value) =>
        {
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMin.x,value);
        });
        tweeningUp = false;
    }
}