using System;
using System.Collections.Generic;
using UnityEngine;
public class SoldierFactory:ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) 
    {
        ISoldier soldier = new ISoldier();
       


         string name;
         int maxHP;
         float moveSpeed;
         string iconSprite;
        
         string prefabName;
        Type t = typeof(T);
        if (t == typeof(SoldierCaptain))
        {
            name = "��ξʿ��";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "CaptainIcon";
            prefabName = "Soldier1";
        }else if (t == typeof(SoldierSergeant))
        {
            name = "��ʿʿ��";
            maxHP = 90;
            moveSpeed = 3;
            iconSprite = "SergeantIcon";
            prefabName = "Soldier3";
        }
        else if (t == typeof(SoldierRookie))
        {
            name = "����ʿ��";
            maxHP = 80;
            moveSpeed = 2.5f;
            iconSprite = "RookieIcon";
            prefabName = "Soldier2";
        }
        else
        {
            Debug.LogError("û��ʿ������"+t);
             return null;
        }
        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), lv,name,maxHP,moveSpeed,iconSprite,prefabName);
        soldier.attr = attr;
        //������ɫ��Ϸ����
        //1.���� 2.ʵ���� TODO
        GameObject characterGO = FactoryManager.AssetFactory.LoadSoldier(prefabName);
        characterGO.transform.position = spawnPosition;
        soldier.gameObject = characterGO;

        //������� TODO
        IWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(weaponType);
        soldier.Weapon = weapon;
        return soldier;
    }
    
}