using System;
using System.Collections.Generic;
using UnityEngine;
public static class FactoryManager
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
    private static IAssetFactory mAssetFactory = null;
    private static ICharacterFactory mSoldierFactory = null;
    private static ICharacterFactory mEnemyFactory = null;
    private static IWeaponFactory mWeaponFactory = null;
    private static IAttrFactory mAttrFactory = null;

    public static IAttrFactory AttrFactory
    {
        get
        {
            if (mAttrFactory == null)
            {
                mAttrFactory = new AttrFactory();
            }
            return mAttrFactory;
        }
    }
    public static IAssetFactory AssetFactory
    {
        get
        {
            if (mAssetFactory == null)
            {
                mAssetFactory = new ResourcesAssetFactory();
            }
            return mAssetFactory;
        }
    }

    public static ICharacterFactory SoldierFactory
    {
        get
        {
            if (mSoldierFactory == null)
            {
                mSoldierFactory = new SoldierFactory();
            }
            return mSoldierFactory;
        }
    }
    public static ICharacterFactory EnemyFactory
    {
        get
        {
            if (mEnemyFactory == null)
            {
                mEnemyFactory = new EnemyFactory();
            }
            return mEnemyFactory;
        }
    }
    public static IWeaponFactory WeaponFactory
    {
        get
        {
            if (mWeaponFactory == null)
            {
                mWeaponFactory = new WeaponFactory();
            }
            return mWeaponFactory;
        }
    }
}