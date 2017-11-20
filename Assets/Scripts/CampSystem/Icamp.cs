﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Icamp {

    protected GameObject mGameObject;
    protected string mName;
    protected string mIconSprite;
    protected SoldierType mSoldierType;
    protected Vector3 mPosition;//集合点
    protected float mTrainTime;
    public List<ITrainCommand> mCommands;
    private float mTrainTimer = 0;
    public Icamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position, float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mIconSprite = icon;
        mSoldierType = soldierType;
        mPosition = position;
        mTrainTime = trainTime;
        mCommands = new List<ITrainCommand>();
        mTrainTimer = mTrainTime;
    }
    public virtual void Update(){
        UpdateCommand();
    }
    public void UpdateCommand(){
        if(mCommands.Count<=0){
            return;
        }
        mTrainTimer-=Time.deltaTime;
        if(mTrainTimer<=0){
            mCommands[0].Execute();
            mCommands.RemoveAt(0);
            mTrainTimer = mTrainTime;
        }
    }
    public string name{
        get{
            return mName;
        }
    }
    public string iconSprite{
        get{
            return mIconSprite;
        }
    }
    public SoldierType soldierType{
        get{
            return mSoldierType;
        }
    }
    public Vector3 Position{
        get{
            return mPosition;
        }
    }
    public float TrainTime{
        get{
            return mTrainTime;
        }
    }
    public abstract int lv{
        get;
    }
    public abstract WeaponType WeaponType{
        get;
    }
    public abstract void Train();
    public  void Cancel(){
        if(mCommands.Count>0){
            mCommands.RemoveAt(mCommands.Count-1);       
            if(mCommands.Count==0){
                mTrainTimer = mTrainTime;
            }
        }
    }
}