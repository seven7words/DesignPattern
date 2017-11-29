using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IStageHandler  {
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
	public IStageHandler SetNextHandler(IStageHandler handler){
		mNextHandler = handler;
		return mNextHandler;
	}
	public int mCountToFinished;
	public StageSystem mStageSystem;
	public IStageHandler (int lv,int countToFinished,StageSystem stageSystem){
		mCountToFinished = countToFinished;
		mLv = lv;
		mStageSystem = stageSystem;
	}
	protected int mLv;//
	public IStageHandler mNextHandler;
	public void Handle(int level){
		if(level==mLv){
			UpdateStage();
			CheckIsFinished();//检查关卡是否结束
		}else{
			mNextHandler.Handle(level);
		}
	}
	private void CheckIsFinished(){
		if(mStageSystem.GetCountOfEnemyKilled()>=mCountToFinished){
			mStageSystem.EnterNextStage();
		}
	}
	public virtual void UpdateStage(){}
}
