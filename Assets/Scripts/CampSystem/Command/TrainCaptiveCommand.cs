using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCaptiveCommand : ITrainCommand
{
	private EnemyType mEnemyType;
	private WeaponType mWeaponType;
	private Vector3 mPosition;
	private int mLv;
	public TrainCaptiveCommand(EnemyType enemyType,WeaponType weapon,Vector3 pos,int lv=1){
		mEnemyType = enemyType;
		mWeaponType = weapon;
		mPosition = pos;
		mLv = lv;
	}
    public override void Execute()
    {
		IEnemy enemy = null;
        switch(mEnemyType){
			case EnemyType.Elf:
				enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(mWeaponType,mPosition) as IEnemy;
			break;
			case EnemyType.Ogre:
				enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(mWeaponType,mPosition) as IEnemy;
			break;
			case EnemyType.Troll:
				enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(mWeaponType,mPosition) as IEnemy;
			break;
			default:
			LogManager.Log("无法创建");
			return;
			break;

		}
		GameFacade.Instance.RemoveEnemy(enemy);
		SoldierCaptive captive = new SoldierCaptive(enemy);
		GameFacade.Instance.AddSoldier(captive);
    }
}
