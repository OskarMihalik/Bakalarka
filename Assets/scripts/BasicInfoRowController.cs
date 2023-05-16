using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicInfoRowController : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI value;

    [SerializeField] private DataBindingConverterDictionary dataBindingConverterDictionary;
    public void SetConverterKey(SustavaReaderEnumKeys key, bool negateBool = false)
    {
        dataBindingConverterDictionary.SetNameOfKey(key);
        dataBindingConverterDictionary.negateBool = negateBool;
    }
}
