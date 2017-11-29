using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public   class WeaponRocket:IWeapon
    {
    //    public override void Fire(Vector3 targetPosition)
    //    {
    //        Debug.Log("显示特效Rocket");
    //        Debug.Log("播放声音Rocket");

    //}
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
    protected override void PlayBulletEffect(Vector3 targetPosition)
        {
            DoPlayBulletEffect(targetPosition, 0.3f);
        }

        protected override void PlaySound()
        {
            DoPlaySound("RocketShot");
        }

        protected override void SetEffectDisplay()
        {
            mEffectDisplayTime = 0.4f;
        }

        public WeaponRocket(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject)
    {
        }
    }

