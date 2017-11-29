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
            Debug.LogError("EnemyStateID Error : trans����Ϊ��");
        }
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("EnemyStateID Error:id״̬Id����Ϊ��");
        }
        if (map.ContainsKey(trans))
        {
            Debug.LogError("EnemyStateID Error " + trans + "�Ѿ������");
        }
        map.Add(trans, stateID);
    }

    public void DeleteTransition(EnemyTransition trans)
    {
        if (map.ContainsKey(trans) == false)
        {
            Debug.LogError("ɾ��ת������������" + trans);
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
            //Debug.LogError("ɾ��ת������������" + trans);
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