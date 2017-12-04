using UnityEngine;
using System.Collections;

public class SoldierCamp : Icamp
{
    #region 常量
        const int MAX_LV = 4;
    #endregion
    #region  属性
        public override int lv{
            get{
                return mLv;
            }
        }
        public override WeaponType WeaponType{
            get{
                return mWeaponType;
            }
        }

        public override int EnergyCostCampUpgrade
        {
            get
            {
                if(mLv == MAX_LV){
                    return -1;
                }else{
                    return mEnergyCostCampUpgrade;
                }
            }
        }

        public override int EnergyCostWeaponUpgrade {
            get
            {
                if(mWeaponType+1 == WeaponType.MAX){
                    return -1;
                }
                else{
                    return mEnergyCostWeaponUpgrade;
                }
            }
        }

        public override int EnergyCostTrain {
            get{
                return mEnergyCostTrain;
            }
        }
    #endregion
    #region 字段
        private int mLv = 1;
        private WeaponType mWeaponType = WeaponType.Gun;
    #endregion
    #region 事件
    #endregion
    #region 方法
        public SoldierCamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position, float trainTime, WeaponType weaponType=WeaponType.Gun, int lv=1):base(gameObject,name,icon,soldierType,position,trainTime){
            mLv = lv;
            mWeaponType = weaponType;
            energyCostStrategy = new SoldierEnergyCostStrategy();
            UpdateEnergyCost();
        }
    

        public override void Train(){
            //添加训练命令
            TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType,mWeaponType,mPosition,mLv);
            mCommands.Add(cmd);
        }

        public override void UpgradeCamp()
        {  
            mLv++;
            UpdateEnergyCost();
        }

        public override void UpgradeWeapon()
        {
            mWeaponType = mWeaponType+1;
            UpdateEnergyCost();
        }

        protected override void UpdateEnergyCost()
        {
            mEnergyCostCampUpgrade = energyCostStrategy.GetCampUpgradeCost(mSoldierType,mLv);
            mEnergyCostWeaponUpgrade = energyCostStrategy.GetWeaponUpgradeCost(mWeaponType);
            mEnergyCostTrain = energyCostStrategy.GetSoldierTrainCost(mSoldierType,mLv);
        }
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
    
   
    
}
