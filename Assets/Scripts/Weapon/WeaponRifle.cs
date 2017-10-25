using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public   class WeaponRifle:IWeapon
    {
    //    public override void Fire(Vector3 targetPosition)
    //    {
    //        Debug.Log("显示特效Rifle");
    //        Debug.Log("播放声音Rifle");
    //        //显示枪口特效
    //        mParticleSystem.Stop();
    //        mParticleSystem.Play();
    //        mLight.enabled = true;
    //        //显示子弹轨迹特效
    //        mLine.enabled = true;
    //        mLine.startWidth = 0.1f;
    //        mLine.endWidth = 0.1f;
    //        mLine.SetPosition(0, mGameObject.transform.position);
    //        mLine.SetPosition(1, targetPosition);
    //        //播放声音
    //        string clipNmae = "RifleShot";
    //        AudioClip clip = null;//TODO
    //        mAudio.clip = clip;
    //        mAudio.Play();
    //}
        protected override void PlayBulletEffect(Vector3 targetPosition)
        {
            DoPlayBulletEffect(targetPosition, 0.1f);
        }

        protected override void PlaySound()
        {
            DoPlaySound("RifleShot");
        }

        protected override void SetEffectDisplay()
        {
            mEffectDisplayTime = 0.3f;
        }

        public WeaponRifle(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject)
    {
        }
    }

