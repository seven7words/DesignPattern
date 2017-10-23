using System;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFSMSystem

{
    private List<IEnemyState> mStates;
    private IEnemyState mCurrentState;

    public IEnemyState currentState
    {
        get { return mCurrentState; }
    }

    public void AddState(params IEnemyState[] states)
    {
        foreach (IEnemyState enemyState in states)
        {
            AddState(enemyState);
        }
    }
    public void AddState(IEnemyState state)
    {
        if (state == null)
        {
            Debug.LogError("要添加的状态为空");
            return;
        }
        if (mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            mCurrentState.DoBeforeEntering();
            return;
        }
        foreach (IEnemyState enemyState in mStates)
        {
            if (enemyState.StateID == state.StateID)
            {
                Debug.LogError("要添加的状态ID" + enemyState.StateID + "已经存在");
            }
        }
        mStates.Add(state);
    }

    public void DeleteState(EnemyStateID stateID)
    {
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("要删除的状态ID为空" + stateID);

        }
        foreach (IEnemyState enemyState in mStates)
        {
            if (enemyState.StateID == stateID)
            {
                mStates.Remove(enemyState);
                return;
            }
        }
        Debug.LogError("要删除的stateID不存在于集合中" + stateID);
    }

    public void PerformTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("要执行的转换条件为空" + trans);
            return;
        }
        EnemyStateID nextStateID = mCurrentState.GetOutPutState(trans);
        if (nextStateID == EnemyStateID.NullState)
        {
            Debug.LogError("在转换条件" + trans + "下没有对应的转换状态");
        }
        foreach (IEnemyState enemyState in mStates)
        {
            if (enemyState.StateID == nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = enemyState;
                mCurrentState.DoBeforeEntering();
            }
        }

    }
}