using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Icamp {

    protected GameObject mGameObject;
    protected string mName;
    protected string mIconSprite;
    protected SoldierType mSoldierType;
    protected Vector3 mPosition;//集合点
    protected float mTrainTime;
    public Icamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position, float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mIconSprite = icon;
        mSoldierType = soldierType;
        mPosition = position;
        mTrainTime = trainTime;
    }
    public virtual void Update(){
        
    }
    
}
