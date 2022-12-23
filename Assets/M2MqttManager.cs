using System;
using System.Collections;
using System.Collections.Generic;
using M2MqttUnity;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt.Messages;

public class M2MqttManager : M2MqttUnityClient
{
    private List<string> eventMessages = new List<string>();
    
    public void PublishPayload(string topic , string payload)
    {
        client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(payload),
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        Debug.Log("message published");
    }
    
    protected override void Update()
    {
        base.Update(); // call ProcessMqttEvents()

        if (eventMessages.Count <= 0) return;
        
        foreach (var msg in eventMessages)
        {
            ProcessMessage(msg);
        }
        eventMessages.Clear();
    }
    
    protected override void DecodeMessage(string topic, byte[] message)
    {
        string msg = System.Text.Encoding.UTF8.GetString(message);
        Debug.Log("Received: " + msg);
        StoreMessage(msg);
    }

    private void StoreMessage(string eventMsg)
    {
        eventMessages.Add(eventMsg);
    }
    
    private void ProcessMessage(string msg)
    {
        Debug.Log("Received: " + msg);
    }
    
    protected override void OnConnecting()
    {
        base.OnConnecting();
        Debug.Log("Connecting to broker on " + brokerAddress + ":" + brokerPort.ToString() + "...\n");
    }

    protected override void OnConnected()
    {
        base.OnConnected();
        Debug.Log("Connected to broker on " + brokerAddress + "\n");

    }

    protected override void SubscribeTopics()
    {
        client.Subscribe(new string[] { Topics.ManualControl, Topics.InitializeValues }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
    }

    protected override void UnsubscribeTopics()
    {
        client.Unsubscribe(new string[] { Topics.ManualControl, Topics.InitializeValues });
    }

    protected override void OnConnectionFailed(string errorMessage)
    {
        Debug.Log("CONNECTION FAILED! " + errorMessage);
    }

    protected override void OnDisconnected()
    {
        Debug.Log("Disconnected.");
    }

    protected override void OnConnectionLost()
    {
        Debug.Log("CONNECTION LOST!");
    }
    
    private void OnDestroy()
    {
        Disconnect();
    }
}