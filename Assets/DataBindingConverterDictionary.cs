using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMVVM.Binding.Converters;

public class DataBindingConverterDictionary : ValueConverterBase
{
    [SerializeField] private SustavaReaderValues nameOfKey;

    public void SetNameOfKey(SustavaReaderValues key)
    {
        nameOfKey = key;
    }

    public override object Convert(object value, Type targetType, object parameter)
    {
        var b = (Dictionary<SustavaReaderValues,string>) value;

        return b[nameOfKey];
    }

    public override object ConvertBack(object value, Type targetType, object parameter)
    {
        throw new NotImplementedException();
    }
}