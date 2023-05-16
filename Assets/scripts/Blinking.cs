using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var image = GetComponent<Image>();
        LeanTween.value(gameObject, 1f, 0.3f, 0.5f).setLoopPingPong().setOnUpdate((value) =>
        {
            var newColor = image.color;
            newColor.a = value;
            image.color = newColor;
        });
    }
}