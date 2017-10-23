using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public   class EnemyAttr:ICharacterAttr
    {
        public EnemyAttr(IAttrStrategy strategy,  string name, int maxHp, float moveSpeed, string iconSprite, string prefabName) : base(strategy,  name,  maxHp,  moveSpeed,  iconSprite,  prefabName)
        {

        }
    }

