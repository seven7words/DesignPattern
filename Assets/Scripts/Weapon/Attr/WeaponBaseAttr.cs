using System;
using System.Collections.Generic;
using UnityEngine;
public class WeaponBaseAttr
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

    protected int mAtk;
    protected float mAtkRange;
    protected string mName;
    protected string mAssetName;
    public WeaponBaseAttr(string name, int atk, float atkRange,string assetName)
    {
        mName = name;
        mAtk = atk;
        mAtkRange = atkRange;
        mAssetName = assetName;
    }

    public string Name
    {
        get { return mName; }
    }

    public float AtkRange
    {
        get { return mAtkRange; }
    }

    public int Atk
    {
        get { return mAtk; }
    }

    public string AssetName
    {
        get { return mAssetName; }
    }
}