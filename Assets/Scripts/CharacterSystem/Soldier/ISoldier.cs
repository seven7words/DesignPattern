using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoldierType{
    Rookie,
    Sergeant,
    Captain,
}
public class ISoldier : ICharacter
{

    protected SoldierFSMSystem mFsmSystem;

    public ISoldier() : base()
    {
        MakeFSM();
    }

    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        if(mIsKilled) return;
        mFsmSystem.currentState.Reason(targets);
        mFsmSystem.currentState.Act(targets);
    }
    private void MakeFSM()
    {
        mFsmSystem = new SoldierFSMSystem();

        SoldierIdleState idleState = new SoldierIdleState(mFsmSystem, this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(mFsmSystem, this);
        chaseState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierAttackState attackState = new SoldierAttackState(mFsmSystem, this);
        attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        mFsmSystem.AddState(idleState,chaseState,attackState);
      
    }

    public override void UnderAttack(int damage)
    {
        if(mIsKilled) return;
        base.UnderAttack(damage);
        if (mAttr.currentHP <= 0)
        {
            PlaySound();
            PlayEffect();
            Killed();
        }
    }

    protected virtual void PlaySound() { }
    protected virtual void PlayEffect() { }
    public override void Killed(){
        base.Killed();
        GameFacade.Instance.NotifySubject(GameEventType.SoldierKilled);
    }
    public override void RunVisitor(ICharacterVisitor visitor){
        visitor.VisitSoldier(this);
    }
}
