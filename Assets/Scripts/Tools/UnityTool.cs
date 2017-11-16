using System;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
public static class UnityTool
{
  public  static void  FindChild(Transform go, List<string> findName, ref List<Transform> tr)

    {

        if (tr.Count == findName.Count)
        {

            return;

        }

        if (go.name.Equals(findName))

        {

            tr.Add(go);

            return;

        }

        if (go.childCount != 0)

        {

            for (int i = 0; i < go.childCount; i++)

            {

                FindChild(go.GetChild(i), findName, ref tr);

            }

        }

    }

    public static GameObject FindChild(GameObject parent, string childName)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        bool isFinded = false;
        Transform myChild = null;
        foreach (Transform child in children)
        {
            if (child.name == childName)
            {
                if (isFinded)
                {
                    Debug.LogWarning("在游戏物体" + parent + "下存在不止一个子物体:" + childName);
                    break;
                }
                isFinded = true;
                myChild = child;

            }
        }
        if(isFinded) return myChild.gameObject;
        return null;
    }

    public static void Attach(GameObject parent, GameObject child)
    {
        child.transform.parent = parent.transform;
        child.transform.localPosition = Vector3.zero;
        child.transform.localScale = Vector3.one;
        child.transform.localEulerAngles = Vector3.zero;
    }
}