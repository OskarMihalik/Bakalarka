using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButtonsController : MonoBehaviour
{
    private List<Button> controlButtons = new List<Button>();

    private Button activeButton;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            var button = child.GetComponent<Button>();
            button.onClick.AddListener(()=>{Activate(button);});
            controlButtons.Add(button);
        }

        activeButton = controlButtons[0];
        activeButton.interactable = false;
    }

    private void Activate(Button button)
    {
        button.interactable = false;
        if (activeButton != null)
            activeButton.interactable = true;
        activeButton = button;
    }
}
