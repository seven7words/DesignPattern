﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    class EnergySystem : IGameSystem
    {
        public override void Init()
        {
           base.Init();
        }

        public override void Release()
        {
            
        }

        public override void Update()
        {
            base.Update();
            mFacade.UpdateEnergySlider((int)mNowEnergy,MAX_Energy);
            if(mNowEnergy>=MAX_Energy)
                return;
            mNowEnergy+=mRecoverSpeed*Time.deltaTime;
            mNowEnergy = Mathf.Min(mNowEnergy,MAX_Energy);
            
        }
        private const int MAX_Energy = 100;
        private float mNowEnergy = MAX_Energy;
        private float mRecoverSpeed= 3;
        public bool TakeEnergy(int value){
            if(mNowEnergy>=value){
                mNowEnergy-=value;
                return true;
            }
            return false;
        }
        public void RecycleEnergy(int value){
            mNowEnergy+=value;
            mNowEnergy = Mathf.Min(mNowEnergy,MAX_Energy);
        }
        
    }

