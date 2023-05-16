using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMVVM.Binding.Converters;

public class DataBindingConverterAlarm : ValueConverterBase
{
    [SerializeField] private GameObject icon;
    
    public override object Convert(object value, Type targetType, object parameter)
    {
        var plcValues = (Dictionary<SustavaReaderEnumKeys,string>) value;

        AlarmCheck(plcValues);
        
        return "";
    }

    public override object ConvertBack(object value, Type targetType, object parameter)
    {
        throw new NotImplementedException();
    }

    private void AlarmCheck(Dictionary<SustavaReaderEnumKeys,string> plcValues)
    {
        var activated = false;
        foreach (var key in SustavaViews.AlarmsKeys)
        {
            var fieldType = SustavaReaderAllKeys.GetFieldTypeFromEnum(key);
            var convertedValue = (bool)Utils.ConvertStringToType(plcValues[key], fieldType);
            if (!convertedValue) continue;
            
            icon.SetActive(true);
            activated = true;
            break;
        }

        if (activated) return;
        
        icon.SetActive(false);
    }
}
