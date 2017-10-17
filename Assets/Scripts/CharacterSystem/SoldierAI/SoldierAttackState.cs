using System;
using System.Collections.Generic;
using UnityEngine;
public class SoldierAttackState:ISoldierState
{
    private float mAttackTime = 1;
    private float mAttackTimer = 1;

    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            mFSM.PerformTransition(SoldierTransition.NoEnemy);
            return;
        }
        float distance = Vector3.Distance(targets[0].Position, mCharacter.Position);
        if (distance > mCharacter.atkRange)
        {
            mFSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
   
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

    public SoldierAttackState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = SoldierStateID.Attack;
        mAttackTimer = mAttackTime;
    }
}