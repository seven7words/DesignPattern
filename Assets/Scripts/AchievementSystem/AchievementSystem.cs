using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AchievementSystem : IGameSystem
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
    private int mEnemyKilledCount = 0;
    private int mSoldierKilledCount = 0;
    private int mMaxStageLv = 1;
    public override void Init(){
        base.Init();
        GameFacade.Instance.RegisterObserver(GameEventType.EnemyKilled,new EnemyKilledObserverArchievement(this));
        GameFacade.Instance.RegisterObserver(GameEventType.SoldierKilled,new SoldierKilledObserverArchievement(this));
        GameFacade.Instance.RegisterObserver(GameEventType.NewStage,new NewStageObserverArchievement(this));
    }
    public void AddEnemyKilledCount(int number =1){
        mEnemyKilledCount+=number;
        LogManager.D("AddEnemyKilledCount{0}",mEnemyKilledCount);
    }
    public void AddSoldierKilledCount(int number = 1){
        mSoldierKilledCount+= number;
         LogManager.D("AddSoldierKilledCount{0}",mSoldierKilledCount);
    }
    public void SetMaxStageLv(int stageLv){
        if(stageLv>mMaxStageLv){
            mMaxStageLv = stageLv;
        }
       LogManager.D("SetMaxStageLv{0}",mMaxStageLv);
    }
    public AchievementMemento CreateMemento(){
        AchievementMemento memento = new AchievementMemento();
        memento.EnemyKilledCount = mEnemyKilledCount;
        memento.SoldierKilledCount = mSoldierKilledCount;
        memento.MaxStageLv = mMaxStageLv;
        return memento;
    }
    public void SetMemento(AchievementMemento memento){
        mEnemyKilledCount = memento.EnemyKilledCount;
        mSoldierKilledCount = memento.SoldierKilledCount;
        mMaxStageLv = memento.MaxStageLv;
    }
}

