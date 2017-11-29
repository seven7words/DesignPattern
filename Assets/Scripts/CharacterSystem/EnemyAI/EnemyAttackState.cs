using System;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAttackState : IEnemyState
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
    public EnemyAttackState(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = EnemyStateID.Attack;
        mAttackTimer = mAttackTime;
    }
    private float mAttackTime = 1;
    private float mAttackTimer = 1;
    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
            return;
        mAttackTimer += Time.deltaTime;
        if (mAttackTimer >= mAttackTime)
        {
            mCharacter.Attack(targets[0]);
            mAttackTimer = 0;
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            mFSM.PerformTransition(EnemyTransition.LostSoldier);
        }
        else
        {
            float distanck = Vector3.Distance(mCharacter.Position, targets[0].Position);
            if (distanck > mCharacter.atkRange)
            {
                mFSM.PerformTransition(EnemyTransition.LostSoldier);
            }
        }
    }
}