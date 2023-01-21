using System;
using System.Collections;
using System.Collections.Generic;

public static class Topics
{
    public static readonly string InitializeValues = "Initialize_values";
    public static readonly string ManualControl = "Manual_control";
    public static readonly string ResetAlarms = "Reset_alarms";
    public static readonly string Start = "Start";
    public static readonly string SwitchControl = "Switch_control";
}

[Serializable]
public class InitializeValuesPayload
{
    
}

[Serializable]
public class ManualControlPayload
{
    public bool slider1_front;
    public bool slider1_back;
    public bool slider2_front;
    public bool slider2_back;
    public bool LED2;
    public bool LED3;
    public bool LED1;
    public bool LED4;
    public bool LED5;
    public bool slider1_go_forward;
    public bool slider1_go_back;
    public bool slider2_go_forward;
    public bool slider2_go_back;
    public bool machine1;
    public bool machine2;
    public bool line1;
    public bool line2;
    public bool line3;
    public bool line4;
}

[Serializable]
public class ResetAlarmsPayload
{
    public bool reset_alarm;
}



