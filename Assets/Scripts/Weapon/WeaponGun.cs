using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public   class WeaponGun:IWeapon
    {
    //public override void Fire(Vector3 targetPosition,string clipName)
    //{
    //    Debug.Log("显示特效Gun");
    //    Debug.Log("播放声音Gun");
    ////显示枪口特效
    //mParticleSystem.Stop();
    //mParticleSystem.Play();
    //    mLight.enabled = true;
    ////显示子弹轨迹特效
    //    mLine.enabled = true;
    //    mLine.startWidth = 0.05f;
    //    mLine.endWidth = 0.05f;
    //    mLine.SetPosition(0,mGameObject.transform.position);
    //mLine.SetPosition(1,targetPosition);
    ////播放声音
    //    string clipNmae = "GunShot";
    //    AudioClip clip = null;//TODO
    //    mAudio.clip = clip;
    //    mAudio.Play();

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
            DoPlayBulletEffect(targetPosition,0.05f);
        }

        protected override void PlaySound()
        {
            DoPlaySound("GunShot");
        }

        protected override void SetEffectDisplay()
        {
            mEffectDisplayTime = 0.2f;
        }

        public WeaponGun(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject)
        {
        }
    }

