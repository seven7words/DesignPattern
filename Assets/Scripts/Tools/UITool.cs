using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class UITool
{
    public static GameObject GetCanvas(string name = "Canvas")
    {
        return GameObject.Find(name);
    }
    public static T FindChild<T>(GameObject parent, string childName)
    {
        GameObject uiGO = UnityTool.FindChild(parent, childName);
        return uiGO.GetComponent<T>();
    }
}

