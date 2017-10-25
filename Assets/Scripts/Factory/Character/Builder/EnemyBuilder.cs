using System;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBuilder:ICharacterBuilder
{
    public EnemyBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 spawnPosition, int lv) : base(character, t, weaponType, spawnPosition, lv)
    {
    }

    public override void AddCharacterAttr()
    {
        IEnemy enemy = new IEnemy();
        string name = "";
        int maxHP = 0;
        float moveSpeed = 0;
        string iconSprite = "";
        if (mT == typeof(EnemyElf))
        {
            name = "С����";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "ElfIcon";
            mPrefabName = "Enemy1";


        }
        else if (mT == typeof(EnemyOgre))
        {
            name = "����";
            maxHP = 120;
            moveSpeed = 4;
            iconSprite = "OgreIcon";
            mPrefabName = "Enemy2";

        }
        else if (mT == typeof(EnemyTroll))
        {
            name = "С����";
            maxHP = 200;
            moveSpeed = 1;
            iconSprite = "TrollIcon";
            mPrefabName = "Enemy3";


        }
        else
        {
            Debug.LogError("û�е�������" + mT);
        }
        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), mLv, name, maxHP, moveSpeed, iconSprite, mPrefabName);
        mCharacter.attr = attr;
    }

    public override void AddGameObject()
    {
        GameObject characterGO = FactoryManager.AssetFactory.LoadEnemy(mPrefabName);
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