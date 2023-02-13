using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButtonsController : MonoBehaviour
{
    public List<Button> controlButtonsTabs = new List<Button>();

    private Button activeButton;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var controlBurron in controlButtonsTabs)
        {
            var button = controlBurron.GetComponent<Button>();
            button.onClick.AddListener(()=>{Activate(button);});
        }

        activeButton = controlButtonsTabs[0];
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
