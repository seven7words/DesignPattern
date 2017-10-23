﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemy : ICharacter {

    EnemyFSMSystem mFSMSystem;
    public IEnemy()
    {
        MakeFSM();
    }
    public void UpdateFSMAI(List<ICharacter> targets)
    {
        mFSMSystem.currentState.Reason(targets);
        mFSMSystem.currentState.Act(targets);

    }
    private void MakeFSM()
    {
        mFSMSystem = new EnemyFSMSystem();
        EnemyChaseState chaseState = new EnemyChaseState(mFSMSystem,this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);
        EnemyAttackState attackState = new EnemyAttackState(mFSMSystem, this);
        attackState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);
        mFSMSystem.AddState(chaseState, attackState);
        }
}
