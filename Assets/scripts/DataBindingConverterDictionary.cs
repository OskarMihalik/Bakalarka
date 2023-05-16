using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityMVVM.Binding.Converters;

public class DataBindingConverterDictionary : ValueConverterBase
{
    [SerializeField] private SustavaReaderEnumKeys nameOfKey;
    [SerializeField] private Color trueColor;
    [SerializeField] private Color falseColor;
    [SerializeField] private Transform panelWithColor;

    private Image panelImage;

    public bool negateBool = false;

    public void SetNameOfKey(SustavaReaderEnumKeys key)
    {
        nameOfKey = key;
    }

    private void Awake()
    {
        panelImage = panelWithColor.GetComponent<Image>();
    }

    public override object Convert(object value, Type targetType, object parameter)
    {
        var b = (Dictionary<SustavaReaderEnumKeys, string>) value;
        var textValue = b[nameOfKey];
        if (textValue == "true" || textValue == "false" && panelImage != null)
        {
            panelImage.gameObject.SetActive(true);
            bool.TryParse(textValue, out var booleanValue);
            if (negateBool)
            {
                booleanValue = !booleanValue;
            }
            panelImage.color = booleanValue ? falseColor : trueColor;
            return booleanValue.ToString();
        }

        return b[nameOfKey];
    }

    public override object ConvertBack(object value, Type targetType, object parameter)
    {
        throw new NotImplementedException();
    }
}