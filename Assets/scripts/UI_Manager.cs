using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private M2MqttManager m2MqttManager;
    
    public Transform canvas;
    public Transform connectButton;
    public Transform resetAlarmsButton;
    public Transform manualControlButton;
    public Transform startPlanButton;

    private void Start()
    {
        m2MqttManager.ConnectionSucceeded += ConnectionSucceeded;
    }

    private void OnDestroy()
    {
        m2MqttManager.ConnectionSucceeded -= ConnectionSucceeded;
    }

    private void ConnectionSucceeded()
    {
        ToggleControls(true);
    }

    public void ToggleUI(bool active)
    {
        canvas.gameObject.SetActive(active);
    }

    private void ToggleControls(bool toggle)
    {
        connectButton.GetComponent<Button>().interactable = toggle;
        resetAlarmsButton.GetComponent<Button>().interactable = toggle;
        manualControlButton.GetComponent<Button>().interactable = toggle;
        startPlanButton.GetComponent<Button>().interactable = toggle;
    }
    
}
