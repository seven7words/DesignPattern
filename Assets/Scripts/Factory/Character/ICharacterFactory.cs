using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public   interface ICharacterFactory
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
     ICharacter CreateCharacter<T>(WeaponType weaponType,Vector3 spawnPosition,int lv =1);
 }

