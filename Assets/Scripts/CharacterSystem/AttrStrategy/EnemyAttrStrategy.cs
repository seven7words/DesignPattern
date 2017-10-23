using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public   class EnemyAttrStrategy:IAttrStrategy
    {
        public int GetExtralHPValue(int lv)
        {
            return 0;
        }

        public int GetDmgDescValue(int lv)
        {
            return 0;
        }

        public int GetCritDmg(float critRate)
        {
         float crit =  UnityEngine. Random.Range(0, 1f);
            if (crit < critRate)
            {
                return (int)(10 * UnityEngine.Random.Range(0.5f, 1f));
         }
            return 0;
        }
    }

