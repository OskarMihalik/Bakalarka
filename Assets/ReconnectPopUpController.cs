using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReconnectPopUpController : MonoBehaviour
{
    [SerializeField] private M2MqttManager m2MqttManager;

    [SerializeField] private TMP_InputField ipInputField;
    [SerializeField] private TMP_InputField portInputField;

    private void OnEnable()
    {
        ipInputField.text = m2MqttManager.brokerAddress;
        portInputField.text = m2MqttManager.brokerPort.ToString();
    }

    public void OnReconnectButtonClick()
    {
        m2MqttManager.brokerAddress = ipInputField.text;
        m2MqttManager.brokerPort = Int32.Parse(portInputField.text);
        gameObject.SetActive(false);
    }
}
