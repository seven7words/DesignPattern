using System;
using System.Collections.Generic;
using UnityEngine;
public class EnemyChaseState : IEnemyState
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
    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = EnemyStateID.Chase;
    }
    private Vector3 mTargetPosition;
    public override void DoBeforeEntering()
    {
        mTargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].Position);
        }
        else
        {
            mCharacter.MoveTo(mTargetPosition);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            //TODO
            float distanck = Vector3.Distance(mCharacter.Position, targets[0].Position);
            if (distanck <= mCharacter.atkRange)
            {
                mFSM.PerformTransition(EnemyTransition.CanAttack);
            }

           
        }
    }
}