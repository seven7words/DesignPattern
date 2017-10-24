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
            name = "С����";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "ElfIcon";
            prefabName = "Enemy1";


        }else if (t == typeof(EnemyOgre))
        {
            name = "����";
            maxHP = 120;
            moveSpeed = 4;
            iconSprite = "OgreIcon";
            prefabName = "Enemy2";

        }
        else if (t == typeof(EnemyTroll))
        {
            name = "С����";
            maxHP = 200;
            moveSpeed = 1;
            iconSprite = "TrollIcon";
            prefabName = "Enemy3";


        }
        else
        {
            Debug.LogError("û�е�������" + t);
            return null;
        }
        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), lv, name, maxHP, moveSpeed, iconSprite, prefabName);
        enemy.attr = attr;
        //������ɫ��Ϸ����
        //1.���� 2.ʵ���� TODO
        GameObject characterGO = FactoryManager.AssetFactory.LoadEnemy(prefabName);
        characterGO.transform.position = spawnPosition;
        enemy.gameObject = characterGO;

        //������� TODO
        IWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(weaponType);
        enemy.Weapon = weapon;
        return enemy;
    }
}