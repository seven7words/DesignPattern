using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementMemento : MonoBehaviour {
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
	public int EnemyKilledCount {get;set;}
    public int SoldierKilledCount {get;set;}
    public int MaxStageLv {get;set;}
	
	 public void SaveData(){
        PlayerPrefs.SetInt("EnemyKilledCount",EnemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount",SoldierKilledCount);
        PlayerPrefs.SetInt("MaxStageLv",MaxStageLv);
    }
    public void LoadData(){
        EnemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount");
        SoldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount");
        MaxStageLv = PlayerPrefs.GetInt("MaxStageLv");
    }
}
