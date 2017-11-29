using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class UITool
{
     #region 常量
    #endregion
    #region  属性
    #endregion
    #region 字段
    #endregion
    #region 事件
    #endregion
    #region 方法
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
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

