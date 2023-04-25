using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityMVVM.ViewModel;

public class ViewModelMqtt : ViewModelBase
{
    #region Binding Properties
    public Dictionary<SustavaReaderEnumKeys, string> PlcValues
    {
        get => plcValues;
        set
        {
            if (value == plcValues) return;
                
            plcValues = value;
            NotifyPropertyChanged(nameof(PlcValues));
        }
    }

    public void ChangePlcValue(SustavaReaderEnumKeys key, string value)
    {
        if (!plcValues.ContainsKey(key))
        {
            Debug.LogWarning("key: " + key +" doesn't exist");
            return;
        }
    
        if (plcValues[key] == value)
        {
            return;
        }
    
        plcValues[key] = value;
        NotifyPropertyChanged(nameof(PlcValues));
    }

    [SerializeField]
    private Dictionary<SustavaReaderEnumKeys, string> plcValues;
    
    #endregion
    private void Awake()
    {
        var newPlcValues = new Dictionary<SustavaReaderEnumKeys, string>();

        foreach (var propertyName in Enum.GetNames(typeof(SustavaReaderEnumKeys)))
        {
            Enum.TryParse(propertyName, out SustavaReaderEnumKeys key);
            newPlcValues.Add(key, "0");
        }

        PlcValues = newPlcValues;
    }
}
