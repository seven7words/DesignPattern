using System;
using System.Collections.Generic;
using UnityEngine;
public class SoldierBuilder:ICharacterBuilder
{
    
    public SoldierBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 spawnPosition, int lv) : base(character, t, weaponType, spawnPosition, lv)
    {
    }

    public override void AddCharacterAttr()
    {
        string name = "";
        int maxHP = 0;
        float moveSpeed = 0;
        string iconSprite = "";

        if (mT == typeof(SoldierCaptain))
        {
            name = "��ξʿ��";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "CaptainIcon";
            mPrefabName = "Soldier1";
        }
        else if (mT == typeof(SoldierSergeant))
        {
            name = "��ʿʿ��";
            maxHP = 90;
            moveSpeed = 3;
            iconSprite = "SergeantIcon";
            mPrefabName = "Soldier3";
        }
        else if (mT == typeof(SoldierRookie))
        {
            name = "����ʿ��";
            maxHP = 80;
            moveSpeed = 2.5f;
            iconSprite = "RookieIcon";
            mPrefabName = "Soldier2";
        }
        else
        {
            Debug.LogError("û��ʿ������" + mT);
        }
        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), mLv, name, maxHP, moveSpeed, iconSprite, mPrefabName);
        mCharacter.attr = attr;
    }

    public override void AddGameObject()
    {
        //������ɫ��Ϸ����
        //1.���� 2.ʵ���� TODO
        GameObject characterGO = FactoryManager.AssetFactory.LoadSoldier(mPrefabName);
        characterGO.transform.position = mSpawnPosition;
        mCharacter.gameObject = characterGO;
    }

    public override void AddWeapon()
    {
        IWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(mWeaponType);
        mCharacter.Weapon = weapon;
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }

    
}