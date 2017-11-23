using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    public class StageSystem:IGameSystem
    {
        int mLv = 1;
        List<Vector3> mPosList;
        Vector3 mTargetPosition;
        IStageHandler mRootHandler;
        public void Init()
        {
           base.Init();
           InitPosition();
           InitStageChain();
        }
        private void InitStageChain(){
            int lv =1;
            NormalStageHandler hanlder1 = new NormalStageHandler(lv++,EnemyType.Elf,WeaponType.Gun,3,GetRandomPos(),lv*2,this);
            NormalStageHandler hanlder2 = new NormalStageHandler(lv++,EnemyType.Elf,WeaponType.Rifle,3,GetRandomPos(),lv*2,this); 
            NormalStageHandler hanlder3 = new NormalStageHandler(lv++,EnemyType.Elf,WeaponType.Rocket,3,GetRandomPos(),lv*2,this);
            NormalStageHandler hanlder4 = new NormalStageHandler(lv++,EnemyType.Ogre,WeaponType.Gun,4,GetRandomPos(),lv*2,this);
            NormalStageHandler hanlder5 = new NormalStageHandler(lv++,EnemyType.Ogre,WeaponType.Rifle,4,GetRandomPos(),lv*2,this);
            NormalStageHandler hanlder6 = new NormalStageHandler(lv++,EnemyType.Ogre,WeaponType.Rocket,4,GetRandomPos(),lv*2,this);
            NormalStageHandler hanlder7 = new NormalStageHandler(lv++,EnemyType.Troll,WeaponType.Gun,5,GetRandomPos(),lv*2,this);
            NormalStageHandler hanlder8 = new NormalStageHandler(lv++,EnemyType.Troll,WeaponType.Rifle,5,GetRandomPos(),lv*2,this);
            NormalStageHandler hanlder9 = new NormalStageHandler(lv++,EnemyType.Troll,WeaponType.Rocket,5,GetRandomPos(),lv*2,this);
            hanlder1.SetNextHandler(hanlder2).SetNextHandler(hanlder3).SetNextHandler(hanlder4)
            .SetNextHandler(hanlder5).SetNextHandler(hanlder6).SetNextHandler(hanlder7)
            .SetNextHandler(hanlder8).SetNextHandler(hanlder9);
            mRootHandler = hanlder1;
        }
        private void InitPosition(){
            mPosList = new List<Vector3>();
            int i = 1;
            while(true){
            GameObject go =  GameObject.Find("Position"+i);
           
                if(go!=null){
                     i++;
                    mPosList.Add(go.transform.position);
                    go.SetActive(false);
                }else{
                    break;
                }
            }
            mTargetPosition = new Vector3();
            GameObject go1 = GameObject.Find("TargetPosition");
            //go1.SetActive(false);
            mTargetPosition = go1.transform.position;
        }
        private Vector3 GetRandomPos(){
            return mPosList[UnityEngine.Random.Range(0,mPosList.Count)];
        }
        public void Update()
        {
            mRootHandler.Handle(mLv);
        }

        public void Release()
        {
           
        }
        public int GetCountOfEnemyKilled(){
            //TODO:
            return 0;
        }
        public void EnterNextStage(){
            //TODO:
            mLv++;
        }
        public Vector3 TargetPosition{
            get{
                return mTargetPosition;
            }
        }
    }

