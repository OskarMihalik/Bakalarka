using System;
using System.Collections;
using System.Collections.Generic;

public static class Topics
{
    public static readonly string InitializeValues = "Initialize_values_from_unity";
    public static readonly string ManualControl = "sustava1-writer";
    public static readonly string ResetAlarms = "Reset_alarms";
    public static readonly string Start = "Start";
    public static readonly string SwitchControl = "Switch_control";
    public static readonly string SustavaReader = "sustava1-reader";
}

public class StoredMessage
{
    public string topic;
    public string message;
}

[Serializable]
public class InitializeValuesPayload
{
    public int hotovy_material;
    public int material_na_linke;
    public int motoHours_line1_count;
    public int motoHours_line1_sek;
    public int motoHours_line1_min;
    public int motoHours_line1_hod;
    public int motoHours_line2_count;
    public int motoHours_line2_sek;
    public int motoHours_line2_min;
    public int motoHours_line2_hod;
    public int motoHours_line3_count;
    public int motoHours_line3_sek;
    public int motoHours_line3_min;
    public int motoHours_line3_hod;
    public int motoHours_line4_count;
    public int motoHours_line4_sek;
    public int motoHours_line4_min;
    public int motoHours_line4_hod;
    public int motoHours_machine1_count;
    public int motoHours_machine1_sek;
    public int motoHours_machine1_min;
    public int motoHours_machine1_hod;
    public int motoHours_machine2_count;
    public int motoHours_machine2_sek;
    public int motoHours_machine2_min;
    public int motoHours_machine2_hod;
}

[Serializable]
public enum SustavaReaderValues
{
    hotovy_material,
    material_na_linke,
    motoHours_line1_count,
    motoHours_line1_sek,
    motoHours_line1_min,
    motoHours_line1_hod,
    motoHours_line2_count,
    motoHours_line2_sek,
    motoHours_line2_min,
    motoHours_line2_hod,
    motoHours_line3_count,
    motoHours_line3_sek,
    motoHours_line3_min,
    motoHours_line3_hod,
    motoHours_line4_count,
    motoHours_line4_sek,
    motoHours_line4_min,
    motoHours_line4_hod,
    motoHours_machine1_count,
    motoHours_machine1_sek,
    motoHours_machine1_min,
    motoHours_machine1_hod,
    motoHours_machine2_count,
    motoHours_machine2_sek,
    motoHours_machine2_min,
    motoHours_machine2_hod,

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



