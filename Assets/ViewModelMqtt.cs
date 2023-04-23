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
    public Dictionary<SustavaReaderValues, string> PlcValues
    {
        get => plcValues;
        set
        {
            if (value == plcValues) return;
                
            plcValues = value;
            NotifyPropertyChanged(nameof(PlcValues));
        }
    }

    public void ChangePlcValue(SustavaReaderValues key, string value)
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
    private Dictionary<SustavaReaderValues, string> plcValues;
    
    #endregion
    private void Awake()
    {
        var newPlcValues = new Dictionary<SustavaReaderValues, string>();

        var properties = typeof(InitializeValuesPayload).GetFields(BindingFlags.Public | BindingFlags.Instance);
        
        foreach (var property in properties)
        {
            SustavaReaderValues key;
            Enum.TryParse(property.Name, out key);
            newPlcValues.Add(key, "0");
        }

        PlcValues = newPlcValues;
    }

    private int vount;
    // Update is called once per frame
    // private void Update()
    // {
    //     vount++;
    //     // ViewModelMqtt
    //     ChangePlcValue(SustavaReaderValues.material_na_linke, vount.ToString() );
    // }
}
