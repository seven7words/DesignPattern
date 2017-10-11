using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public   class WeaponGun:IWeapon
    {
        public override void Fire(Vector3 targetPosition)
        {
            Debug.Log("显示特效Gun");
            Debug.Log("播放声音Gun");
    }
    }

