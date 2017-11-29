using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveCountVisitor : ICharacterVisitor
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
	public int enemyCount{
		get;private set;
	}
	public int soldierCount{get;private set;}
    public override void VisitEnemy(IEnemy enemy)
    {
		if(enemy.isKilled == false)
        	enemyCount+=1;
    }
	public void Reset(){
		enemyCount=0;
		soldierCount = 0;
	}
    public override void VisitSoldier(ISoldier soldier)
    {
		if(soldier.isKilled == false)
        soldierCount+=1;
    }
}
