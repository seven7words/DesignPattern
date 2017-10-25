using System;
using System.Collections.Generic;
using UnityEngine;
public class WeaponBaseAttr
{

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