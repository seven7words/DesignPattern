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
        if(uiGO==null) {
            Debug.Log("在游戏物体"+parent+"下面找不到"+childName);
            return default(T);
        }
        return uiGO.GetComponent<T>();
    }
}

