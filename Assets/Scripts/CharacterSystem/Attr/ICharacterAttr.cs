using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public   class ICharacterAttr
 {
     protected CharacterBaseAttr mBaseAttr;

        protected int mCurrentHP;
        protected int mLv;
        protected int mDmgDescValue;

        public ICharacterAttr(IAttrStrategy strategy,int lv,CharacterBaseAttr baseAttr)
        {
            mLv = lv;
            mBaseAttr = baseAttr;
        mStrategy = strategy;
        mDmgDescValue = mStrategy.GetCritDmg(mLv);
            mCurrentHP = baseAttr.MaxHP + mStrategy.GetExtralHPValue(mLv);
            
        }
    //增加的最大血量，抵御的伤害值，暴击增加的伤害
        protected IAttrStrategy mStrategy;

        public int critValue
        {
            get { return mStrategy.GetCritDmg(mBaseAttr.CritRate); }
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

