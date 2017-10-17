using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISoldier : ICharacter
{

    protected SoldierFSMSystem mFsmSystem;

    public ISoldier() : base()
    {
        MakeFSM();
    }

    public void UpdateFSMAI(List<ICharacter> targets)
    {
        mFsmSystem.currentState.Reason(targets);
        mFsmSystem.currentState.Act(targets);
    }
    private void MakeFSM()
    {
        mFsmSystem = new SoldierFSMSystem();
        SoldierIdleState idleState = new SoldierIdleState(mFsmSystem,this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(mFsmSystem,this);
        chaseState.AddTransition(SoldierTransition.NoEnemy,SoldierStateID.Idle);
         chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);
        SoldierAttackState attackState = new SoldierAttackState(mFsmSystem,this);
        attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);
        mFsmSystem.AddState(idleState,chaseState,attackState);
      
    }
}
