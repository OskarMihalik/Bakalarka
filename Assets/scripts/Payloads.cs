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
public class SustavaReaderAllKeys
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
    public bool reset_count_on_plant;
    public bool reset_count_completed;
    public bool start;
    public bool alarm_pas1;
    public bool alarm_posuvnik1;
    public bool alarm_pas2;
    public bool alarm_pas3;
    public bool alarm_posuvnik2;
    public bool alarm_pas4;
    public bool reset_alarms;
    public bool switch_control;
    public bool reset_count_line1;
    public bool reset_count_line2;
    public bool reset_count_line3;
    public bool reset_count_line4;
    public bool reset_count_machine1;
    public bool reset_count_machine2;
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
    
    public static Type GetFieldTypeFromEnum(SustavaReaderEnumKeys enumValue)
    {
        string fieldName = enumValue.ToString(); // Get the field name as a string from the enum
        var fieldInfo = typeof(SustavaReaderAllKeys).GetField(fieldName); // Get the field info using reflection

        if (fieldInfo != null)
        {
            return fieldInfo.FieldType;
        }

        throw new ArgumentException($"Field not found for enum value '{enumValue}'.");
    }
}

[Serializable]
public enum SustavaReaderEnumKeys
{
    slider1_front,
    slider1_back,
    slider2_front,
    slider2_back,
    LED2,
    LED3,
    LED1,
    LED4,
    LED5,
    slider1_go_forward,
    slider1_go_back,
    slider2_go_forward,
    slider2_go_back,
    machine1,
    machine2,
    line1,
    line2,
    line3,
    line4,
    reset_count_on_plant,
    reset_count_completed,
    start,
    alarm_pas1,
    alarm_posuvnik1,
    alarm_pas2,
    alarm_pas3,
    alarm_posuvnik2,
    alarm_pas4,
    reset_alarms,
    switch_control,
    reset_count_line1,
    reset_count_line2,
    reset_count_line3,
    reset_count_line4,
    reset_count_machine1,
    reset_count_machine2,
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

public static class SustavaViews
{
    public static readonly List<SustavaReaderEnumKeys> BasicInfoKeys = new List<SustavaReaderEnumKeys>()
    {
        SustavaReaderEnumKeys.LED2,
        SustavaReaderEnumKeys.LED3,
        SustavaReaderEnumKeys.LED1,
        SustavaReaderEnumKeys.LED4,
        SustavaReaderEnumKeys.LED5,
        SustavaReaderEnumKeys.hotovy_material,
        SustavaReaderEnumKeys.material_na_linke,
        SustavaReaderEnumKeys.motoHours_line1_count,
        SustavaReaderEnumKeys.motoHours_line1_sek,
        SustavaReaderEnumKeys.motoHours_line1_min,
        SustavaReaderEnumKeys.motoHours_line1_hod,
        SustavaReaderEnumKeys.motoHours_line2_count,
        SustavaReaderEnumKeys.motoHours_line2_sek,
        SustavaReaderEnumKeys.motoHours_line2_min,
        SustavaReaderEnumKeys.motoHours_line2_hod,
        SustavaReaderEnumKeys.motoHours_line3_count,
        SustavaReaderEnumKeys.motoHours_line3_sek,
        SustavaReaderEnumKeys.motoHours_line3_min,
        SustavaReaderEnumKeys.motoHours_line3_hod,
        SustavaReaderEnumKeys.motoHours_line4_count,
        SustavaReaderEnumKeys.motoHours_line4_sek,
        SustavaReaderEnumKeys.motoHours_line4_min,
        SustavaReaderEnumKeys.motoHours_line4_hod,
        SustavaReaderEnumKeys.motoHours_machine1_count,
        SustavaReaderEnumKeys.motoHours_machine1_sek,
        SustavaReaderEnumKeys.motoHours_machine1_min,
        SustavaReaderEnumKeys.motoHours_machine1_hod,
        SustavaReaderEnumKeys.motoHours_machine2_count,
        SustavaReaderEnumKeys.motoHours_machine2_sek,
        SustavaReaderEnumKeys.motoHours_machine2_min,
        SustavaReaderEnumKeys.motoHours_machine2_hod,
    };
    
    public static readonly List<SustavaReaderEnumKeys> ControllableKeys = new List<SustavaReaderEnumKeys>()
    {
        SustavaReaderEnumKeys.line1,
        SustavaReaderEnumKeys.line2,
        SustavaReaderEnumKeys.line3,
        SustavaReaderEnumKeys.line4,
        SustavaReaderEnumKeys.slider1_front,
        SustavaReaderEnumKeys.slider1_back,
        SustavaReaderEnumKeys.slider2_front,
        SustavaReaderEnumKeys.slider2_back,
        SustavaReaderEnumKeys.machine1,
        SustavaReaderEnumKeys.machine2,
    };
    
    public static readonly List<SustavaReaderEnumKeys> AlarmsKeys = new List<SustavaReaderEnumKeys>()
    {
        SustavaReaderEnumKeys.alarm_pas1,
        SustavaReaderEnumKeys.alarm_posuvnik1,
        SustavaReaderEnumKeys.alarm_pas2,
        SustavaReaderEnumKeys.alarm_pas3,
        SustavaReaderEnumKeys.alarm_posuvnik2,
        SustavaReaderEnumKeys.alarm_pas4,
    };
    
    public static readonly List<SustavaReaderEnumKeys> ResetAlarmsKeys = new List<SustavaReaderEnumKeys>()
    {
        SustavaReaderEnumKeys.reset_count_line1,
        SustavaReaderEnumKeys.reset_count_line2,
        SustavaReaderEnumKeys.reset_count_line3,
        SustavaReaderEnumKeys.reset_count_line4,
        SustavaReaderEnumKeys.reset_count_machine1,
        SustavaReaderEnumKeys.reset_count_machine2,
        SustavaReaderEnumKeys.reset_count_on_plant,
        SustavaReaderEnumKeys.reset_count_completed,
    };
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



