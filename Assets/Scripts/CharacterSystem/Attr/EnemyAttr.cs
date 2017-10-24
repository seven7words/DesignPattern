using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public   class EnemyAttr:ICharacterAttr
    {
        public EnemyAttr(IAttrStrategy strategy, int lv, string name, int maxHp, float moveSpeed, string iconSprite, string prefabName) : base(strategy, lv, name, maxHp, moveSpeed, iconSprite, prefabName)
        {
        }
    }

