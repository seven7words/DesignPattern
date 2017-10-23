using System;
using System.Collections.Generic;
using UnityEngine;
public class SoldierFactory:ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) 
    {
        ISoldier soldier = new ISoldier();
        //创建角色游戏物体
        //1.加载 2.实例化 TODO
        //添加武器 TODO


         string name;
         int maxHP;
         float moveSpeed;
         string iconSprite;
        
         string prefabName;
        Type t = typeof(T);
        if (t == typeof(SoldierCaptain))
        {
            name = "上尉士兵";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "CaptainIcon";
            prefabName = "Soldier1";
        }else if (t == typeof(SoldierSergeant))
        {
            name = "中士士兵";
            maxHP = 90;
            moveSpeed = 3;
            iconSprite = "SergeantIcon";
            prefabName = "Soldier3";
        }
        else if (t == typeof(SoldierRookie))
        {
            name = "新手士兵";
            maxHP = 80;
            moveSpeed = 2.5f;
            iconSprite = "RookieIcon";
            prefabName = "Soldier2";
        }
        else
        {
            Debug.LogError("没有士兵类型"+t);
             return null;
        }
        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), name,maxHP,moveSpeed,iconSprite,prefabName);
        soldier.attr = attr;
        return soldier;
    }
    
}