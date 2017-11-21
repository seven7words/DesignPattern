using System;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
public abstract class ICharacterBuilder
{
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