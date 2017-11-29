using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType{
   Elf,
   Ogre,
   Troll,
}
public class IEnemy : ICharacter {

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
    EnemyFSMSystem mFSMSystem;
    public IEnemy()
    {
        MakeFSM();
    }
    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        if(mIsKilled) return;
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

    public override void UnderAttack(int damage)
    {
        if(mIsKilled) return;
        base.UnderAttack(damage);
        PlayEffect();
        if (mAttr.currentHP <= 0)
        {
            Killed();
        } 
    }

    protected virtual void PlayEffect()
    {
        
    }
    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.NotifySubject(GameEventType.EnemyKilled);
    }
    public override void RunVisitor(ICharacterVisitor visitor){
        visitor.VisitEnemy(this);
    }
        
}
