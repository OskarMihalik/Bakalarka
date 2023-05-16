using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMVVM.Binding.Converters;

public class DataBindingConverterManualControlButton : ValueConverterBase
{
    [SerializeField] private ToggleController toggleController;
    public SustavaReaderEnumKeys keyToWatch;
    
    public override object Convert(object value, Type targetType, object parameter)
    {
        var plcValues = (Dictionary<SustavaReaderEnumKeys,string>) value;

        Toggle(plcValues);
        
        return "data-bind";
    }

    public override object ConvertBack(object value, Type targetType, object parameter)
    {
        throw new NotImplementedException();
    }

    private void Toggle( Dictionary<SustavaReaderEnumKeys,string> plcValues)
    {
        var fieldType = SustavaReaderAllKeys.GetFieldTypeFromEnum(keyToWatch);
        var convertedValue = (bool)Utils.ConvertStringToType(plcValues[keyToWatch], fieldType);
        toggleController.Toggle(convertedValue, false);
    }
}