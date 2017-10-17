using System;
using System.Collections.Generic;
using UnityEngine;
public class SoldierIdleState : ISoldierState
{
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