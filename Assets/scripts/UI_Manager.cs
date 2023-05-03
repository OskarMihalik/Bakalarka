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
    [Header("Contents")]
    public Transform manualControlContent;
    public Transform basicInfoContent;
    public Transform alarmsInfoContent;
    [Header("Panels")]
    public Transform basicInfo;
    public Transform manualControlHolder;
    public Transform connectPanel;
    public Transform alarmsPanel;
    public Transform controllButtonsShower;
    [Header("Prefabs")]
    public GameObject listItemPrefab;
    public GameObject basicInfoRowPrefab;

    private Transform activeBottomDrawerPanel;
    private Transform activeControlButton;
    
    private ViewModelMqtt viewModelMqtt;
    
    private void Awake()
    {
        m2MqttManager.ConnectionSucceeded += ConnectionSucceeded;
        m2MqttManager.ConnectionFailed += OnDisconnect;
        m2MqttManager.ConnectionDisconnected += OnDisconnect;
        CreateManualControlButtons();
        m2MqttManager.AddActionToReceivedTopic(Topics.InitializeValues, CreateBasicInfoListItems);
        activeBottomDrawerPanel = connectPanel;
        activeControlButton = basicInfoButton;
    }

    private void Start()
    {
        m2MqttManager.AddActionToReceivedTopic(Topics.SustavaReader, OnSustavaReaderReceive);
        CreateAlarmsInfoListItems();
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
        foreach (var propertyName in Enum.GetNames(typeof(SustavaReaderEnumKeys)))
        {
            if (!jsonDict.ContainsKey(propertyName)) continue;
            var property = jsonDict[propertyName];
            if (string.IsNullOrEmpty(property)) continue;
            Enum.TryParse(propertyName, out SustavaReaderEnumKeys key);
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
    
    private void OnDisconnect()
    {
        ToggleControls(false);
        ToggleConnectPanel();
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
    
    public void ToggleAlarmsPanel()
    {
        ChangeActiveBottomDrawerPanel(alarmsPanel);
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
        controllButtonsShower.gameObject.SetActive(toggle);
    }

    private void CreateManualControlButtons()
    {
        foreach (var property in SustavaViews.ControllableKeys)
        {
            var listItem = Instantiate(listItemPrefab, manualControlContent, false);
            var listItemController = listItem.GetComponent<ListItemController>();
            var listItemConverter = listItem.GetComponent<DataBindingConverterManualControlButton>();
            listItemConverter.keyToWatch = property;
            var propertyName = property.ToString();
            listItemController.title.text = propertyName.Replace("_", " ");
            listItemController.toggleController.onToggleOff.AddListener(delegate
            {
                m2MqttPayloads.ToggleOnePart(false, propertyName);
            });
            listItemController.toggleController.onToggleOn.AddListener(delegate
            {
                m2MqttPayloads.ToggleOnePart(true, propertyName);
            });
        }
    }

    private void CreateBasicInfoListItems(string _)
    {
        foreach (var key in SustavaViews.BasicInfoKeys)
        {
            var basicInfoRow = Instantiate(basicInfoRowPrefab, basicInfoContent, false);
            var basicInfoRowController = basicInfoRow.GetComponent<BasicInfoRowController>();
            
            basicInfoRowController.title.text = key.ToString().Replace("_", " ");
            basicInfoRowController.SetConverterKey(key);
        }
    }
    
    private void CreateAlarmsInfoListItems()
    {
        foreach (var key in SustavaViews.AlarmsKeys)
        {
            var basicInfoRow = Instantiate(basicInfoRowPrefab, alarmsInfoContent, false);
            var basicInfoRowController = basicInfoRow.GetComponent<BasicInfoRowController>();
            
            basicInfoRowController.title.text = key.ToString().Replace("_", " ");
            basicInfoRowController.SetConverterKey(key);
        }
    }
}