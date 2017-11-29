using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageSubject : IGameEventSubject {
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
	private int mStageCount = 1;
	public int StageCount{
		get{
			return mStageCount;
		}
	}
	public override void Notify(){
		mStageCount++;
		base.Notify();
	}
}
