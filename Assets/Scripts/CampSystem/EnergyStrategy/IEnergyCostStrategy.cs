/*
 * @Author: zhuhuiling 
 * @Date: 2017-11-21 23:45:15 
 * @Last Modified by: zhuhuiling
 * @Last Modified time: 2017-11-21 23:55:43
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//能量消耗策略
public interface IEnergyCostStrategy  {
	#region 常量
    #endregion
    #region  属性
    #endregion
    #region 字段
    #endregion
    #region 事件
    #endregion
    #region 方法
        int GetCampUpgradeCost(SoldierType st,int lv);
        int GetWeaponUpgradeCost(WeaponType wt);
        int GetSoldierTrainCost(SoldierType st,int lv);
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
	
}
