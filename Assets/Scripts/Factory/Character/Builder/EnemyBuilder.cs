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
        CharacterBaseAttr baseAttr = FactoryManager.AttrFactory.GetCharacterBaseAttr(mT);
        mPrefabName = baseAttr.PrefabName;
        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), mLv, baseAttr);
        mCharacter.attr = attr;
    }

    public override void AddGameObject()
    {
        GameObject characterGO = FactoryManager.AssetFactory.LoadEnemy(mPrefabName);
        characterGO.transform.position = mSpawnPosition;
        mCharacter.gameObject = characterGO;
    }

    public override void AddInCharacterSystem()
    {
       GameFacade.Instance.AddEnemy(mCharacter as IEnemy);
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