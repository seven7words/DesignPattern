using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public   class WeaponRifle:IWeapon
    {
        public override void Fire(Vector3 targetPosition)
        {
            Debug.Log("显示特效Rifle");
            Debug.Log("播放声音Rifle");
        }
    }

