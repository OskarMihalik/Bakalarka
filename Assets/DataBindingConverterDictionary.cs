using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMVVM.Binding.Converters;

public class DataBindingConverterDictionary : ValueConverterBase
{
    [SerializeField] private SustavaReaderEnumKeys nameOfKey;

    public void SetNameOfKey(SustavaReaderEnumKeys key)
    {
        nameOfKey = key;
    }

    public override object Convert(object value, Type targetType, object parameter)
    {
        var b = (Dictionary<SustavaReaderEnumKeys,string>) value;

        return b[nameOfKey];
    }

    public override object ConvertBack(object value, Type targetType, object parameter)
    {
        throw new NotImplementedException();
    }
}