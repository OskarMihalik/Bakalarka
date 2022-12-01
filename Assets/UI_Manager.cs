using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public Transform canvas;

    public void ToggleUI(bool active)
    {
        canvas.gameObject.SetActive(active);
    }
    
}
