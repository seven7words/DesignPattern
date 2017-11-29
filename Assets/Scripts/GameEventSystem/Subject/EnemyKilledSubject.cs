using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledSubject : IGameEventSubject {
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
	private int mKilledCount = 0 ;
	public int KilledCount {
		get{
			return mKilledCount;
		}
	}
	public override void Notify(){
		mKilledCount++;
		base.Notify();
	}
}
