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

	 int GetCampUpgradeCost(SoldierType st,int lv);
	 int GetWeaponUpgradeCost(WeaponType wt);
	 int GetSoldierTrainCost(SoldierType st,int lv);
}
