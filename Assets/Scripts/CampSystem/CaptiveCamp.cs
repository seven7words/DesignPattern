using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptiveCamp : Icamp
{
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
	private EnemyType mEnemyType;
    private WeaponType mWeaponType = WeaponType.Gun;
	public CaptiveCamp(GameObject gameObject, string name, string icon, EnemyType enemyType, Vector3 position, float trainTime):base(gameObject,name,icon,SoldierType.Captive,position,trainTime){
        mEnemyType = enemyType;
		 energyCostStrategy = new SoldierEnergyCostStrategy();
		 UpdateEnergyCost();
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
}
