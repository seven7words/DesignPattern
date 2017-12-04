using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SoldierEnergyCostStrategy : IEnergyCostStrategy
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
		public int GetCampUpgradeCost(SoldierType st, int lv)
		{
			int energy = 0;
			switch(st){
				case SoldierType.Rookie:
					energy = 60;
					break;
				case SoldierType.Sergeant:
					energy = 65;
					break;
				case SoldierType.Captain:
					energy = 70;
					break;
				default:
					LogManager.E("无法获取"+st+"这个类型兵营升级所消耗的能量值");
					break;
			}
			return GetEnergy(lv,energy);
		}

		public int GetSoldierTrainCost(SoldierType st, int lv)
		{
			int energy = 0;
			switch(st){
				case SoldierType.Rookie:
					energy = 10;
					break;
				case SoldierType.Sergeant:
					energy = 15;
					break;
				case SoldierType.Captain:
					energy = 20;
					break;
				case SoldierType.Captive:
					return 10;
				default:
					LogManager.E("无法获取"+st+"这个类型兵营升级所消耗的能量值");
					break;
			}
			
			return GetEnergy(lv,energy);
		}
		private int GetEnergy(int lv, int energy){
			energy+=(lv-1)*2;
			if(energy>100) energy = 100;
			return energy;
		}
		public int GetWeaponUpgradeCost(WeaponType wt)
		{
			int energy = 0;
			switch(wt){
				case WeaponType.Gun:
					energy = 30;
					break;
				case WeaponType.Rifle:
					energy = 40;
					break;
				default:
					Debug.LogError("无法获取"+wt+"升级所消耗的能量值");
					break;
			}
			return energy;
		}
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
	
}
