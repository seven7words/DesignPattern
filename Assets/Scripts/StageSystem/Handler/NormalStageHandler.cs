using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStageHandler :IStageHandler {
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
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private int mCount;
    private Vector3 mPosition;
    private int mCountToFinished;
    private StageSystem mStageSystem;
    private int mSpawnTime = 3;
    private float mSpawnTimer = 0;

    private int mCountSpawned = 0;
    public override void UpdateStage(){
        base.UpdateStage();
        if(mCountSpawned<mCount){
            mSpawnTimer-=Time.deltaTime;
            if(mSpawnTimer<=0){
                SpawnEnemy();
                mSpawnTimer = mSpawnTime;
            }
        }
    }
    public NormalStageHandler(int lv,EnemyType et,WeaponType wt,int count,Vector3 pos,int countToFinished,StageSystem stageSystem):base(lv,countToFinished,stageSystem){
        mEnemyType = et;
        mWeaponType = wt;
        mCount = count;
        mPosition = pos;
        mSpawnTimer = mSpawnTime;

    }
    void SpawnEnemy(){
        mCountSpawned++;
        switch(mEnemyType){
            case EnemyType.Elf:
            FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(mWeaponType,mPosition);
            break;
            case EnemyType.Ogre:
            FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(mWeaponType,mPosition);
            break;
            case EnemyType.Troll:
            FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(mWeaponType,mPosition);
            break;
            default:
            Debug.LogError("无法生程"+mEnemyType+"类型敌人");
            break;
        }
        //FactoryManager.EnemyFactory.CreateCharacter()
    }
}