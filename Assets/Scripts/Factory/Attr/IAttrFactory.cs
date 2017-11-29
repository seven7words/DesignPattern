using System;
using System.Collections.Generic;
using UnityEngine;
public  interface IAttrFactory
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
 CharacterBaseAttr GetCharacterBaseAttr(Type t);
  WeaponBaseAttr  GetWeaponBaseAttr(WeaponType weaponType);
}