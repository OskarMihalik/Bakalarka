using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2MqttPayloads : MonoBehaviour
{
    [SerializeField] private M2MqttManager m2MqttManager;

    public void ResetAlarms()
    {
        // {"reset_alarm":true}
        var payload = new ResetAlarmsPayload() {reset_alarm = true};
        m2MqttManager.PublishPayload(Topics.ResetAlarms, JsonUtility.ToJson(payload));
    }

    public void ToggleOnePart(bool toggle, string part)
    {
        var payload = $"{{ \"{part}\":{toggle.ToString().ToLower()} }}";
        m2MqttManager.PublishPayload(Topics.ManualControl, payload);
    }
}