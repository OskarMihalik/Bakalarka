using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private M2MqttManager m2MqttManager;
    [SerializeField] private M2MqttPayloads m2MqttPayloads;

    public Transform canvas;
    public Transform connectButton;
    public Transform resetAlarmsButton;
    public Transform manualControlButton;
    public Transform startPlanButton;
    public Transform ManualControlContent;

    public GameObject ListItemPrefab;

    private void Start()
    {
        // m2MqttManager.Connect();
        m2MqttManager.ConnectionSucceeded += ConnectionSucceeded;
        CreateManualControlButtons();
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
        // connectButton.GetComponent<Button>().interactable = toggle;
        resetAlarmsButton.GetComponent<Button>().interactable = toggle;
        manualControlButton.GetComponent<Button>().interactable = toggle;
        startPlanButton.GetComponent<Button>().interactable = toggle;
    }

    private void CreateManualControlButtons()
    {
        var properties = typeof(ManualControlPayload).GetFields(BindingFlags.Public | BindingFlags.Instance);
        Debug.Log(properties.Length);
        foreach (var property in properties)
        {
            var listItem = Instantiate(ListItemPrefab, ManualControlContent, true);
            var listItemController = listItem.GetComponent<ListItemController>();

            listItemController.title.text = property.Name;
            listItemController.toggleController.onToggleOff.AddListener(delegate
            {
                m2MqttPayloads.ToggleOnePart(false, property.Name);
            });
            listItemController.toggleController.onToggleOn.AddListener(delegate
            {
                m2MqttPayloads.ToggleOnePart(true, property.Name);
            });
        }
    }
}