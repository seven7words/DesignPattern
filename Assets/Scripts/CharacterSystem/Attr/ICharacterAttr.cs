using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public   class ICharacterAttr
    {
        protected string mName;
        protected int mMaxHP;
        protected float mMoveSpeed;
        protected string mIconSprite;

        protected string mPrefabName;

    protected int mCurrentHP;
        protected int mLv;
        protected float mCritRate;//0-1暴击率

        protected int mDmgDescValue;

        public ICharacterAttr(IAttrStrategy strategy,string name,int maxHp,float moveSpeed,string iconSprite,string prefabName)
        {
            mName = name;
            mMaxHP = maxHp;
            mMoveSpeed = moveSpeed;
            mIconSprite = iconSprite;
            mPrefabName = prefabName;
            mStrategy = strategy;
        mDmgDescValue = mStrategy.GetCritDmg(mCritRate);
            mCurrentHP = mMaxHP + mStrategy.GetExtralHPValue(mLv);
        }
    //增加的最大血量，抵御的伤害值，暴击增加的伤害
        protected IAttrStrategy mStrategy;

        public int critValue
        {
            get { return mDmgDescValue; }
        }

        public int currentHP
        {
            get { return mCurrentHP; }
        }


        public void TakeDamage(int damage)
        {

            damage -= mDmgDescValue;
            if (damage < 5)
                damage = 5;
            mCurrentHP -= damage;
        }
    }

