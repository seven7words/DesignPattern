using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public   class EnemyAttrStrategy:IAttrStrategy
    {
         #region 常量
    #endregion
    #region  属性
    #endregion
    #region 字段
    #endregion
    #region 事件
    #endregion
    #region 方法
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
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

