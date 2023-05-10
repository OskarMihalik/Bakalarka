using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2MqttPayloads : MonoBehaviour
{
    [SerializeField] private M2MqttManager m2MqttManager;

    public void ResetAlarms()
    {
        ToggleOnePart(true, SustavaReaderEnumKeys.reset_alarms.ToString());
    }   
    public void InitializeValues()
    {
        m2MqttManager.PublishPayload(Topics.InitializeValues, "payload: true");
    }

    public void ToggleOnePart(bool toggle, string part)
    {
        var payload = $"{{ \"{part}\":{toggle.ToString().ToLower()} }}";
        m2MqttManager.PublishPayload(Topics.ManualControl, payload);
    }
    
    public void ToggleOnePartInTopic(bool toggle, string part, string topic)
    {
        var payload = $"{{ \"{part}\":{toggle.ToString().ToLower()} }}";
        m2MqttManager.PublishPayload(topic, payload);
    }
}