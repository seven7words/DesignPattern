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
        //��������
        mCharacterBaseAttrsDict.Add(typeof(SoldierRookie),new CharacterBaseAttr("����ʿ��",80,2.5f,"RookieIcon",0,"Soldier2"));
        mCharacterBaseAttrsDict.Add(typeof(SoldierSergeant), new CharacterBaseAttr("��ʿʿ��", 90, 3f, "SergeantIcon", 0, "Soldier3"));
        mCharacterBaseAttrsDict.Add(typeof(SoldierCaptain), new CharacterBaseAttr("��ξʿ��", 100, 3f, "CaptainIcon", 0, "Soldier1"));
        //��������
        mCharacterBaseAttrsDict.Add(typeof(EnemyElf), new CharacterBaseAttr("С����", 100, 3f, "ElfIcon", 0.2f, "Enemy1"));
        mCharacterBaseAttrsDict.Add(typeof(EnemyOgre), new CharacterBaseAttr("����", 120, 4f, "OgreIcon", 0.3f, "Enemy2"));
        mCharacterBaseAttrsDict.Add(typeof(EnemyTroll), new CharacterBaseAttr("��ħ", 200, 1f, "TrollIcon", 0.4f, "Enemy3"));

    }

    private void InitWeaponBaseAttr()
    {
     mWeaponBaseAttrsDict = new Dictionary<WeaponType, WeaponBaseAttr>();   
        mWeaponBaseAttrsDict.Add(WeaponType.Gun, new WeaponBaseAttr("��ǹ",20,5,"WeaponGun"));
        mWeaponBaseAttrsDict.Add(WeaponType.Rifle, new WeaponBaseAttr("��ǹ", 30, 7, "WeaponRifle"));
        mWeaponBaseAttrsDict.Add(WeaponType.Rocket, new WeaponBaseAttr("���", 40, 8, "WeaponRocket"));
    }

    public CharacterBaseAttr GetCharacterBaseAttr(Type t)
    {
        if (mCharacterBaseAttrsDict.ContainsKey(t) == false)
        {
            Debug.LogError("�޷�������������" + t + "�õ���ɫ��������(GetCharacterBaseAttr)");
            return null;
        }
        return mCharacterBaseAttrsDict[t];
    }

    public WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType)
    {
        if (mWeaponBaseAttrsDict.ContainsKey(weaponType) == false)
        {
            Debug.LogError("�޷�������������" + weaponType + "�õ���ɫ��������(GetCharacterBaseAttr)");
            return null;
        }
        return mWeaponBaseAttrsDict[weaponType];
    }
}