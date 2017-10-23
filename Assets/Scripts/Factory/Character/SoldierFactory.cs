using System;
using System.Collections.Generic;
using UnityEngine;
public class SoldierFactory:ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) 
    {
        ISoldier soldier = new ISoldier();
        //������ɫ��Ϸ����
        //1.���� 2.ʵ���� TODO
        //������� TODO


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
        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), name,maxHP,moveSpeed,iconSprite,prefabName);
        soldier.attr = attr;
        return soldier;
    }
    
}