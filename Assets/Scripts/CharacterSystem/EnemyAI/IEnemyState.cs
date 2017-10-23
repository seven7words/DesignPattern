using System;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyTransition
{
    NullTransition = 0,
    CanAttack,
    LostSoldier,
   
}

public enum EnemyStateID
{
    NullState,
    Chase,
    Attack,
}
public abstract class IEnemyState
{
    protected ICharacter mCharacter;
    protected Dictionary<EnemyTransition, EnemyStateID> map = new Dictionary<EnemyTransition, EnemyStateID>();
    protected EnemyStateID mStateID;
    protected EnemyFSMSystem mFSM;

    public IEnemyState(EnemyFSMSystem fsm, ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }
    public EnemyStateID StateID
    {
        get { return mStateID; }
    }

    public void AddTransition(EnemyTransition trans, EnemyStateID stateID)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("EnemyStateID Error : trans不能为空");
        }
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("EnemyStateID Error:id状态Id不能为空");
        }
        if (map.ContainsKey(trans))
        {
            Debug.LogError("EnemyStateID Error " + trans + "已经添加上");
        }
        map.Add(trans, stateID);
    }

    public void DeleteTransition(EnemyTransition trans)
    {
        if (map.ContainsKey(trans) == false)
        {
            Debug.LogError("删除转换条件不存在" + trans);
        }
        else
        {
            map.Remove(trans);
        }
    }

    public EnemyStateID GetOutPutState(EnemyTransition trans)
    {
        if (map.ContainsKey(trans) == false)
        {
            //Debug.LogError("删除转换条件不存在" + trans);
            return EnemyStateID.NullState;
        }
        else
        {
            return map[trans];
        }
    }

    public virtual void DoBeforeEntering()
    {

    }

    public virtual void DoBeforeLeaving()
    {

    }

    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);
}