using System;
using System.Collections.Generic;
using UnityEngine;
public class AttrFactory:IAttrFactory
{
    private Dictionary<Type, CharacterBaseAttr> mCharacterBaseAttrsDict;
    private Dictionary<WeaponType, WeaponBaseAttr> mWeaponBaseAttrsDict;
    public AttrFactory()
    {
        InitCharacterBaseAttr();
        InitWeaponBaseAttr();
    }

    private void InitCharacterBaseAttr()
    {
        mCharacterBaseAttrsDict = new Dictionary<Type, CharacterBaseAttr>();
        //人物属性
        mCharacterBaseAttrsDict.Add(typeof(SoldierRookie),new CharacterBaseAttr("新手士兵",80,2.5f,"RookieIcon",0,"Soldier2"));
        mCharacterBaseAttrsDict.Add(typeof(SoldierSergeant), new CharacterBaseAttr("中士士兵", 90, 3f, "SergeantIcon", 0, "Soldier3"));
        mCharacterBaseAttrsDict.Add(typeof(SoldierCaptain), new CharacterBaseAttr("上尉士兵", 100, 3f, "CaptainIcon", 0, "Soldier1"));
        //敌人属性
        mCharacterBaseAttrsDict.Add(typeof(EnemyElf), new CharacterBaseAttr("小精灵", 100, 3f, "ElfIcon", 0.2f, "Enemy1"));
        mCharacterBaseAttrsDict.Add(typeof(EnemyOgre), new CharacterBaseAttr("怪物", 120, 4f, "OgreIcon", 0.3f, "Enemy2"));
        mCharacterBaseAttrsDict.Add(typeof(EnemyTroll), new CharacterBaseAttr("巨魔", 200, 1f, "TrollIcon", 0.4f, "Enemy3"));

    }

    private void InitWeaponBaseAttr()
    {
     mWeaponBaseAttrsDict = new Dictionary<WeaponType, WeaponBaseAttr>();   
        mWeaponBaseAttrsDict.Add(WeaponType.Gun, new WeaponBaseAttr("手枪",20,5,"WeaponGun"));
        mWeaponBaseAttrsDict.Add(WeaponType.Rifle, new WeaponBaseAttr("长枪", 30, 7, "WeaponRifle"));
        mWeaponBaseAttrsDict.Add(WeaponType.Rocket, new WeaponBaseAttr("火箭", 40, 8, "WeaponRocket"));
    }

    public CharacterBaseAttr GetCharacterBaseAttr(Type t)
    {
        if (mCharacterBaseAttrsDict.ContainsKey(t) == false)
        {
            Debug.LogError("无法根据所给类型" + t + "得到角色基础属性(GetCharacterBaseAttr)");
            return null;
        }
        return mCharacterBaseAttrsDict[t];
    }

    public WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType)
    {
        if (mWeaponBaseAttrsDict.ContainsKey(weaponType) == false)
        {
            Debug.LogError("无法根据所给类型" + weaponType + "得到角色基础属性(GetCharacterBaseAttr)");
            return null;
        }
        return mWeaponBaseAttrsDict[weaponType];
    }
}