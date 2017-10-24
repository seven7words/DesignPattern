using System;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFactory:ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1)
    {
        IEnemy enemy = new IEnemy();
        string name;
        int maxHP;
        float moveSpeed;
        string iconSprite;

        string prefabName;
        Type t = typeof(T);
        if (t == typeof(EnemyElf))
        {
            name = "小精灵";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "ElfIcon";
            prefabName = "Enemy1";


        }else if (t == typeof(EnemyOgre))
        {
            name = "怪物";
            maxHP = 120;
            moveSpeed = 4;
            iconSprite = "OgreIcon";
            prefabName = "Enemy2";

        }
        else if (t == typeof(EnemyTroll))
        {
            name = "小精灵";
            maxHP = 200;
            moveSpeed = 1;
            iconSprite = "TrollIcon";
            prefabName = "Enemy3";


        }
        else
        {
            Debug.LogError("没有敌人类型" + t);
            return null;
        }
        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), lv, name, maxHP, moveSpeed, iconSprite, prefabName);
        enemy.attr = attr;
        //创建角色游戏物体
        //1.加载 2.实例化 TODO
        GameObject characterGO = FactoryManager.AssetFactory.LoadEnemy(prefabName);
        characterGO.transform.position = spawnPosition;
        enemy.gameObject = characterGO;

        //添加武器 TODO
        IWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(weaponType);
        enemy.Weapon = weapon;
        return enemy;
    }
}