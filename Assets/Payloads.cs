using System;
using System.Collections;
using System.Collections.Generic;

public static class Topics
{
    public static readonly string InitializeValues = "Initialize_values";
    public static readonly string ManualControl = "Manual_control";
}

[Serializable]
public class InitializeValues
{
    
}

[Serializable]
public class ManualControl 
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


