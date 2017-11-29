using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public  class SoldierFSMSystem
  {
      private List<ISoldierState> mStates = new List<ISoldierState>();
      private ISoldierState mCurrentState;

      public ISoldierState currentState
      {
          get { return mCurrentState; }
      }

      public void AddState(params ISoldierState[] states)
      {
          
          foreach (ISoldierState soldierState in states)
          {
              AddState(soldierState);
          }
      }
      public void AddState(ISoldierState state)
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
              return;
          }
          foreach (ISoldierState soldierState in mStates)
          {
              if (soldierState.StateID == state.StateID)
              {
                  Debug.LogError("要添加的状态ID"+soldierState.StateID+"已经存在");
              }
          }
          mStates.Add(state);
      }

      public void DeleteState(SoldierStateID stateID)
      {
          if (stateID == SoldierStateID.NullState)
          {
              Debug.LogError("要删除的状态ID为空"+stateID);

          }
          foreach (ISoldierState soldierState in mStates)
          {
              if (soldierState.StateID == stateID)
              {
                  mStates.Remove(soldierState);
                  return;
              }
          }
          Debug.LogError("要删除的stateID不存在于集合中"+stateID);
      }

      public void PerformTransition(SoldierTransition trans)
      {
          if (trans == SoldierTransition.NullTransition)
          {
              Debug.LogError("要执行的转换条件为空"+trans);
              return;
          }
      SoldierStateID nextStateID =    mCurrentState.GetOutPutState(trans);
          if (nextStateID == SoldierStateID.NullState)
          {
              Debug.LogError("在转换条件"+trans+"下没有对应的转换状态");
          }
          foreach (ISoldierState soldierState in mStates)
          {
              if (soldierState.StateID == nextStateID)
              {
                  mCurrentState.DoBeforeLeaving();
                  mCurrentState = soldierState;
                mCurrentState.DoBeforeEntering();
              }
          }

    }
  }

