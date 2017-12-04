using System;
using System.Collections.Generic;
using UnityEngine;
public class CharacterBaseAttr
{
    #region 常量
    #endregion
    #region  属性
        public string Name
        {
            get { return mName; }
        }

        public int MaxHP
        {
            get { return mMaxHP; }
        }

        public float MoveSpeed
        {
            get { return mMoveSpeed; }
        }

        public string IconSprite
        {
            get { return mIconSprite; }
        }

        public float CritRate
        {
            get { return mCritRate; }
        }

        public string PrefabName
        {
            get { return mPrefabName; }
        }
    #endregion
    #region 字段
        protected string mName;
        protected int mMaxHP;
        protected float mMoveSpeed;
        protected string mIconSprite;
        protected float mCritRate;//0-1的暴击值
        protected string mPrefabName;

    #endregion
    #region 事件
    #endregion
    #region 方法
        public CharacterBaseAttr(string name,int maxHP,float moveSpeed,string iconSprite,float critRate,string prefabName)
        {
            mName= name;
            mMaxHP = maxHP;
            mMoveSpeed = moveSpeed;
            mIconSprite = iconSprite;
            mCritRate = critRate;
            mPrefabName = prefabName;
        }
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
    
    

    
}