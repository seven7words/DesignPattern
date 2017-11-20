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
        CharacterBaseAttr baseAttr = FactoryManager.AttrFactory.GetCharacterBaseAttr(mT);
        mPrefabName = baseAttr.PrefabName;
        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), mLv, baseAttr);
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