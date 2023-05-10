using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAlarmsButtonController : MonoBehaviour
{
    public M2MqttPayloads m2MqttPayloads;

    public void ResetAlarms()
    {
        m2MqttPayloads.ToggleOnePartInTopic(true, SustavaReaderEnumKeys.reset_alarms.ToString(), Topics.ManualControl);
    } 
}
