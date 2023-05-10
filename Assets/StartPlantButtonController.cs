using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityMVVM.Util;

public class StartPlantButtonController : MonoBehaviour
{
    public M2MqttPayloads m2MqttPayloads;
    private ViewModelMqtt viewModelMqtt;

    private void Start()
    {
        viewModelMqtt = ViewModelProvider.Instance.GetViewModelInstance<ViewModelMqtt>();

    }

    public void StopStartPlant()
    {
        m2MqttPayloads.ToggleOnePartInTopic(!Convert.ToBoolean(viewModelMqtt.PlcValues[SustavaReaderEnumKeys.start]) , "start", Topics.ManualControl);
    }
}