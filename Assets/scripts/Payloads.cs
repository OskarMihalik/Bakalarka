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
    public bool line1;
    public bool line2;
    public bool line3;
    public bool line4;
    public bool machine1;
    public bool machine2;
    public bool slider1Forward;
    public bool slider1Back;
    public bool slider2Forward;
    public bool slider2Back;
}

[Serializable]
public class ResetAlarmsPayload
{
    public bool reset_alarm;
}


