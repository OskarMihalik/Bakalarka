using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityMVVM.Util;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private M2MqttManager m2MqttManager;
    [SerializeField] private M2MqttPayloads m2MqttPayloads;

    public Transform canvas;
    public Transform controlButtons;
    public Transform basicInfoButton;
    public Transform manualControlContent;
    public Transform basicInfoContent;
    public Transform basicInfo;
    public Transform manualControlHolder;
    public Transform connectPanel;
    
    public GameObject listItemPrefab;
    public GameObject basicInfoRowPrefab;

    private Transform activeBottomDrawerPanel;
    private Transform activeControlButton;

    private int vount;
    private ViewModelMqtt viewModelMqtt;
    
    private void Awake()
    {
        m2MqttManager.ConnectionSucceeded += ConnectionSucceeded;
        CreateManualControlButtons();
        m2MqttManager.AddActionToReceivedTopic(Topics.InitializeValues, CreateBasicInfoListItems);
        activeBottomDrawerPanel = connectPanel;
        activeControlButton = basicInfoButton;
    }

    private void Start()
    {
        m2MqttManager.AddActionToReceivedTopic(Topics.SustavaReader, OnSustavaReaderReceive);

        viewModelMqtt = ViewModelProvider.Instance.GetViewModelInstance<ViewModelMqtt>();
    }

    private void OnSustavaReaderReceive(string message)
    {
        var jsonDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);
        if (jsonDict == null)
        {
            Debug.LogWarning("can't convert to dictionary, message: " + message);
            return;
        }
        foreach (var propertyName in Enum.GetNames(typeof(SustavaReaderValues)))
        {
            if (!jsonDict.ContainsKey(propertyName)) continue;
            var property = jsonDict[propertyName];
            if (string.IsNullOrEmpty(property)) continue;
            Enum.TryParse(propertyName, out SustavaReaderValues key);
            viewModelMqtt.ChangePlcValue(key, property );
            Console.WriteLine(propertyName);
            break;
        }
    }

    private void OnDestroy()
    {
        m2MqttManager.ConnectionSucceeded -= ConnectionSucceeded;
    }

    private void ConnectionSucceeded()
    {
        m2MqttPayloads.InitializeValues();
        ToggleControls(true);
        ToggleBasicInfo();
    }

    public void ToggleUI(bool active)
    {
        canvas.gameObject.SetActive(active);
    }

    public void ToggleBasicInfo()
    {
        ChangeActiveBottomDrawerPanel(basicInfo);
    }

    public void ToggleConnectPanel()
    {
        ChangeActiveBottomDrawerPanel(connectPanel);
    }

    public void ToggleManualControlHolder()
    {
        ChangeActiveBottomDrawerPanel(manualControlHolder);
        m2MqttPayloads.ToggleOnePartInTopic(true, "switch_control", Topics.SwitchControl);
    }

    private void ChangeActiveBottomDrawerPanel(Transform newPanel)
    {
        if (activeBottomDrawerPanel != null && activeControlButton != null)
        {
            activeBottomDrawerPanel.gameObject.SetActive(false);
        }
        activeBottomDrawerPanel = newPanel;
        newPanel.gameObject.SetActive(true);
    }

    private void ToggleControls(bool toggle)
    {
        controlButtons.gameObject.SetActive(toggle);
        // resetAlarmsButton.gameObject.SetActive(toggle);
        // manualControlButton.gameObject.SetActive(toggle);
        // startPlanButton.gameObject.SetActive(toggle);
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

    private void CreateBasicInfoListItems(string _)
    {
        var properties = typeof(InitializeValuesPayload).GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            var basicInfoRow = Instantiate(basicInfoRowPrefab, basicInfoContent, false);
            var basicInfoRowController = basicInfoRow.GetComponent<BasicInfoRowController>();
            
            basicInfoRowController.title.text = property.Name.Replace("_", " ");
            Enum.TryParse(property.Name, out SustavaReaderValues key);
            basicInfoRowController.SetConverterKey(key);
        }
    }
}