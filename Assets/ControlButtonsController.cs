using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButtonsController : MonoBehaviour
{
    public List<Button> controlButtonsTabs = new List<Button>();

    private Button activeButton;

    private float rectStart;

    private RectTransform rectTransform;

    public float rectTransformLeft;

    // Start is called before the first frame update
    private void Start()
    {
        foreach (var controlButton in controlButtonsTabs)
        {
            var button = controlButton.GetComponent<Button>();
            button.onClick.AddListener(() => { Activate(button); });
        }

        activeButton = controlButtonsTabs[0];
        activeButton.interactable = false;
        rectTransform = transform.GetComponent<RectTransform>();
        rectStart = rectTransform.offsetMin.x;
    }

    private void Activate(Button button)
    {
        button.interactable = false;
        if (activeButton != null)
            activeButton.interactable = true;
        activeButton = button;
    }

    public void TweenLeft()
    {
        var start = rectStart;
        if (LeanTween.isTweening(gameObject))
        {
            LeanTween.cancel(gameObject);
            start = rectTransform.offsetMin.x;
        }
        LeanTween.value(gameObject, start, rectTransformLeft, .5f).setOnUpdate((value) =>
        {
            rectTransform.offsetMin = new Vector2(value, rectTransform.offsetMin.y);
        });
    }

    public void TweenRight()
    {
        var start = rectTransformLeft;
        if (LeanTween.isTweening(gameObject))
        {
            LeanTween.cancel(gameObject);
            start = rectTransform.offsetMin.x;
        }

        LeanTween.value(gameObject, start, rectStart, .5f).setOnUpdate((value) =>
        {
            rectTransform.offsetMin = new Vector2(value, rectTransform.offsetMin.y);
        });
    }
}