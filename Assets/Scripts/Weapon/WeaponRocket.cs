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
    }

