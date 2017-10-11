﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public abstract   class IWeapon
{
    protected int mAtk;
    protected float mAtkRange;
    protected int mAtkPlusValue;
    protected GameObject mGameObject;

    protected ICharacter mOwner;

    protected ParticleSystem mParticleSystem;
    protected LineRenderer mLine;
    protected Light mLight;
    protected AudioSource mAudio;
    public abstract void Fire(Vector3 targetPosition);
}

