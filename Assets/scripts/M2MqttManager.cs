using System;
using System.Collections.Generic;
using M2MqttUnity;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt.Messages;

public class M2MqttManager : M2MqttUnityClient
{
    private List<StoredMessage> eventMessages = new List<StoredMessage>();
    private Dictionary<string, Action<string>> eventActions = new Dictionary<string, Action<string>>();

    /// <summary>
    /// Event fired when connection lost
    /// </summary>
    public event Action ConnectionLost;

    public void PublishPayload(string topic, string payload)
    {
        client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(payload),
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        Debug.Log("message published topic: " + topic);
    }

    public void AddActionToReceivedTopic(string topic, Action<string> action)
    {
        eventActions.Add(topic, action);
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
        Debug.Log("DecodeMessage: " + msg + " // Topic:" + topic);
        StoreMessage(topic, msg);
    }

    private void StoreMessage(string topic, string message)
    {
        eventMessages.Add(new StoredMessage {topic = topic, message = message});
    }

    private void ProcessMessage(StoredMessage msg)
    {
        if (eventActions.ContainsKey(msg.topic))
        {
            eventActions[msg.topic](msg.message);
            return;
        }

        Debug.LogWarning("no registered action with topic: " + msg.topic + " payload:" + msg.message);
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
        client.Subscribe(
            new string[]
                {Topics.ManualControl, Topics.InitializeValues, Topics.SustavaReader, Topics.GetInitializeValues},
            new byte[]
            {
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE
            });
    }

    protected override void UnsubscribeTopics()
    {
        client.Unsubscribe(new string[]
            {Topics.ManualControl, Topics.InitializeValues});
    }

    protected override void OnConnectionFailed(string errorMessage)
    {
        Debug.Log("CONNECTION FAILED! " + errorMessage);
        ConnectionLost?.Invoke();
    }

    protected override void OnDisconnected()
    {
        Debug.Log("Disconnected.");
    }

    protected override void OnConnectionLost()
    {
        Debug.Log("CONNECTION LOST!");
        ConnectionLost?.Invoke();
    }

    private void OnDestroy()
    {
        Disconnect();
    }
}