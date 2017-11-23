using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IStageHandler  {
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
