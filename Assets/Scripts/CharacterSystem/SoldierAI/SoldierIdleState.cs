using System;
using System.Collections.Generic;
using UnityEngine;
public class SoldierIdleState : ISoldierState
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
    public override void Act(List<ICharacter> targets)
    {
        mCharacter.PlayAnim("stand");
    }
    public SoldierIdleState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
   
    {
        mStateID = SoldierStateID.Idle;
        
    }
    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mFSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}