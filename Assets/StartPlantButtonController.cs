using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPlantButtonController : MonoBehaviour
{
    public M2MqttPayloads m2MqttPayloads;
    
    public void StopStartPlant(bool toggle)
    {
        m2MqttPayloads.ToggleOnePartInTopic(toggle, "start", Topics.ManualControl);
    }
}