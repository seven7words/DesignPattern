using System;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFSMSystem

{
    private List<IEnemyState> mStates = new List<IEnemyState>();
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
            Debug.LogError("Ҫ��ӵ�״̬Ϊ��");
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
                Debug.LogError("Ҫ��ӵ�״̬ID" + enemyState.StateID + "�Ѿ�����");
            }
        }
        mStates.Add(state);
    }

    public void DeleteState(EnemyStateID stateID)
    {
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("Ҫɾ����״̬IDΪ��" + stateID);

        }
        foreach (IEnemyState enemyState in mStates)
        {
            if (enemyState.StateID == stateID)
            {
                mStates.Remove(enemyState);
                return;
            }
        }
        Debug.LogError("Ҫɾ����stateID�������ڼ�����" + stateID);
    }

    public void PerformTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("Ҫִ�е�ת������Ϊ��" + trans);
            return;
        }
        EnemyStateID nextStateID = mCurrentState.GetOutPutState(trans);
        if (nextStateID == EnemyStateID.NullState)
        {
            Debug.LogError("��ת������" + trans + "��û�ж�Ӧ��ת��״̬");
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