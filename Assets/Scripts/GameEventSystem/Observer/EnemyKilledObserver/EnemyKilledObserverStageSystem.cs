using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledObserverStageSystem : IGameEventObserver {
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
	private EnemyKilledSubject mSubject;
	private StageSystem mStageSystem;
	public EnemyKilledObserverStageSystem(StageSystem ss){
		mStageSystem = ss;
	}
    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as EnemyKilledSubject;

    }

    public override void Update()
    {
        mStageSystem.CountOfEnemyKilled = mSubject.KilledCount;
    }
}
