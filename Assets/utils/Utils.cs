using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{
    public static object CreateVariableFromType(Type type)
    {
        return Activator.CreateInstance(type);
    }
    
    public static object ConvertStringToType(string value, Type targetType)
    {
        return Convert.ChangeType(value, targetType);
    }
}
