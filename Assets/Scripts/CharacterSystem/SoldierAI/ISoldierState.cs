using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public enum SoldierTransition
{
    NullTransition =0,
    SeeEnemy,
    NoEnemy,
    CanAttack,
}

public enum SoldierStateID
{
    NullState,
    Idle,
    Chase,
    Attack,
}
 public abstract class ISoldierState
 {
     protected ICharacter mCharacter;
    protected Dictionary<SoldierTransition,SoldierStateID> map = new Dictionary<SoldierTransition, SoldierStateID>();
        protected SoldierStateID mStateID;
     protected SoldierFSMSystem mFSM;

     public ISoldierState(SoldierFSMSystem fsm,ICharacter character)
     {
         mFSM = fsm;
         mCharacter = character;
     }
        public SoldierStateID StateID
        {
            get { return mStateID; }
        }
       
        public void AddTransition(SoldierTransition trans, SoldierStateID stateID)
        {
            if (trans == SoldierTransition.NullTransition)
            {
                Debug.LogError("SoldierState Error : trans不能为空");
            }
            if (stateID == SoldierStateID.NullState)
            {
                Debug.LogError("SoldierState Error:id状态Id不能为空");
            }
            if (map.ContainsKey(trans))
            {
                Debug.LogError("SoldierState Error "+trans+"已经添加上");
            }
            map.Add(trans,stateID);
        }

        public void DeleteTransition(SoldierTransition trans)
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

        public SoldierStateID GetOutPutState(SoldierTransition trans)
        {
        if (map.ContainsKey(trans) == false)
        {
            //Debug.LogError("删除转换条件不存在" + trans);
            return SoldierStateID.NullState;
        }
        else
        {
             return    map[trans];
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

