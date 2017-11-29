/*
 * @Author: zhuhuiling 
 * @Date: 2017-11-16 23:22:42 
 * @Last Modified by: zhuhuiling
 * @Last Modified time: 2017-11-16 23:31:43
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public   class CampSystem : IGameSystem
{
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
    private Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();
    private Dictionary<EnemyType,CaptiveCamp> mCamptiveCamp = new Dictionary<EnemyType, CaptiveCamp>();
    public override void Init(){
        base.Init();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);
        InitCamp(EnemyType.Elf);
    }
    private void InitCamp(EnemyType enemyType){
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = "";

        string icon = "";
        Vector3 position = Vector3.zero;
        float trainTime = 0f;
        switch (enemyType)
        {
            case EnemyType.Elf:
                gameObjectName = "CaptiveCamp_Elf";
                name = "伏兵营";
                icon = "CaptiveCamp";
                trainTime = 3f;
                break;
            default:
                Debug.LogError("无法根据战士类型"+enemyType+"初始化兵营");
                break;
        }
        gameObject = GameObject.Find(gameObjectName);
        position = UnityTool.FindChild(gameObject,"TrainPoint").transform.position;
        CaptiveCamp camp = new CaptiveCamp(gameObject,name,icon,enemyType,position,trainTime);
        CampOnClick campOnClick = gameObject.AddComponent<CampOnClick>();
        campOnClick.camp = camp;
        mCamptiveCamp.Add(enemyType, camp);
    }
    private void InitCamp(SoldierType soldierType){
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = "";

        string icon = "";
        Vector3 position = Vector3.zero;
        float trainTime = 0f;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                gameObjectName = "SoldierCamp_Rookie";
                name = "新手兵营";
                icon = "RookieCamp";
                trainTime = 3f;
                break;
            case SoldierType.Sergeant:
                gameObjectName = "SoldierCamp_Sergeant";
                name = "中士兵营";
                icon = "SergeantCamp";
                trainTime = 4f;
                break;
            case SoldierType.Captain:
                gameObjectName = "SoldierCamp_Captain";
                name = "上尉兵营";
                icon = "CaptainCamp";
                trainTime = 5f;
                break;
            default:
                Debug.LogError("无法根据战士类型"+soldierType+"初始化兵营");
                break;
        }
        gameObject = GameObject.Find(gameObjectName);
        position = UnityTool.FindChild(gameObject,"TrainPoint").transform.position;
        SoldierCamp camp = new SoldierCamp(gameObject,name,icon,soldierType,position,trainTime);
        CampOnClick campOnClick = gameObject.AddComponent<CampOnClick>();
        campOnClick.camp = camp;
        mSoldierCamps.Add(soldierType, camp);
    }
    public override void  Update(){
        // 更新兵营内部游戏逻辑
        foreach(SoldierCamp camp in mSoldierCamps.Values){
            camp.Update();
        }
        foreach(CaptiveCamp camp in mCamptiveCamp.Values){
            camp.Update();
        }
    }
}

