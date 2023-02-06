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
    public Transform manualControlContent;
    public Transform basicInfoContent;
    
    public GameObject listItemPrefab;
    public GameObject basicInfoRowPrefab;

    private void Start()
    {
        // m2MqttManager.Connect();
        m2MqttManager.ConnectionSucceeded += ConnectionSucceeded;
        CreateManualControlButtons();
        m2MqttManager.AddActionToReceivedTopic(Topics.InitializeValues, CreateBasicInfoListItems);
    }

    private void OnDestroy()
    {
        m2MqttManager.ConnectionSucceeded -= ConnectionSucceeded;
    }

    private void ConnectionSucceeded()
    {
        m2MqttPayloads.InitializeValues();
        ToggleControls(true);
    }

    public void ToggleUI(bool active)
    {
        canvas.gameObject.SetActive(active);
    }

    private void ToggleControls(bool toggle)
    {
        // connectButton.GetComponent<Button>().interactable = toggle;
        resetAlarmsButton.gameObject.SetActive(toggle);
        manualControlButton.gameObject.SetActive(toggle);
        startPlanButton.gameObject.SetActive(toggle);
    }

    private void CreateManualControlButtons()
    {
        var properties = typeof(ManualControlPayload).GetFields(BindingFlags.Public | BindingFlags.Instance);
        
        foreach (var property in properties)
        {
            var listItem = Instantiate(listItemPrefab, manualControlContent, false);
            var listItemController = listItem.GetComponent<ListItemController>();
            
            listItemController.title.text = property.Name.Replace("_", " ");
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

    private void CreateBasicInfoListItems()
    {
        // mock
        var initializeValuesPayload = new InitializeValuesPayload();
        
        var properties = typeof(InitializeValuesPayload).GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            var basicInfoRow = Instantiate(basicInfoRowPrefab, basicInfoContent, false);
            var basicInfoRowController = basicInfoRow.GetComponent<BasicInfoRowController>();
            
            basicInfoRowController.title.text = property.Name.Replace("_", " ");
            basicInfoRowController.value.text =
                initializeValuesPayload.GetType().GetField(property.Name).GetValue(initializeValuesPayload).ToString();

        }
    }
}