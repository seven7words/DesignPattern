using System;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFactory:ICharacterFactory
{
     #region 常量
    #endregion
    #region  属性
    #endregion
    #region 字段
    #endregion
    #region 事件
    #endregion
    #region 方法
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1)
    {
        IEnemy enemy = new IEnemy();
        ICharacterBuilder builder = new EnemyBuilder(enemy, typeof(T), weaponType, spawnPosition, lv);
        return CharacterBuilderDirector.Construct(builder);

    }
}