using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptiveCamp : Icamp
{
    #region 常量
    #endregion
    #region  属性
        public override int lv{
            get{
                return 1;
            }
        }

        public override WeaponType WeaponType{
            get{
                return mWeaponType;
            }
        }
        public override int EnergyCostCampUpgrade {
            get{
                return 0;
            }
        }

        public override int EnergyCostWeaponUpgrade {
            get{
                return 0;
            }
        }

        public override int EnergyCostTrain {
            get{
            return mEnergyCostTrain;
            }
            
        }
    #endregion
    #region 字段
        private EnemyType mEnemyType;
        private WeaponType mWeaponType = WeaponType.Gun;
    #endregion
    #region 事件
    #endregion
    #region 方法
        public CaptiveCamp(GameObject gameObject, string name, string icon, EnemyType enemyType, Vector3 position, float trainTime):base(gameObject,name,icon,SoldierType.Captive,position,trainTime){
            mEnemyType = enemyType;
            energyCostStrategy = new SoldierEnergyCostStrategy();
            UpdateEnergyCost();
        }
    

        public override void Train()
        {
            //添加训练命令
            TrainCaptiveCommand cmd = new TrainCaptiveCommand(mEnemyType,mWeaponType,mPosition);
            mCommands.Add(cmd);
        }

        public override void UpgradeCamp()
        {
            return;
        }

        public override void UpgradeWeapon()
        {
            return;
        }

        protected override void UpdateEnergyCost()
        {
            mEnergyCostTrain = energyCostStrategy.GetSoldierTrainCost(SoldierType.Captive,1); 	
        }
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
    
	
	
}
