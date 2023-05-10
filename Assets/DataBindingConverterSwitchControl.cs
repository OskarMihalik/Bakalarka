using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMVVM.Binding.Converters;

public class DataBindingConverterSwitchControl : ValueConverterBase
{
    [SerializeField] private ToggleController toggleController;

    public override object Convert(object value, Type targetType, object parameter)
    {
        var toggle = (bool) value;

        Toggle(toggle);

        return "data-bind";
    }

    public override object ConvertBack(object value, Type targetType, object parameter)
    {
        throw new NotImplementedException();
    }

    private void Toggle(bool toggle)
    {
        toggleController.Toggle(toggle, false);
    }
}