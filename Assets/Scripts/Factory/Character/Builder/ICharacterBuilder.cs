using System;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
public abstract class ICharacterBuilder
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
    protected Type mT;
    protected WeaponType mWeaponType;
    protected Vector3 mSpawnPosition;
    protected int mLv;
    protected ICharacter mCharacter;
    protected string mPrefabName = " ";
    public ICharacterBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 spawnPosition, int lv)
    {
        mCharacter = character;
        mT = t;
        mWeaponType = weaponType;
        mSpawnPosition = spawnPosition;
        mLv = lv;
    }

public  abstract  void  AddCharacterAttr();
    public abstract void AddGameObject();
    public abstract void AddWeapon();
    public abstract ICharacter GetResult();
    public abstract void AddInCharacterSystem();
}