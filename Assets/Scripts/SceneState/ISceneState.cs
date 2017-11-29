using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public   class ISceneState
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
     private string mSceneName;
     private SceneStateController mController;

     public  SceneStateController Controller
     {
         get {  return mController; }
     }
     public ISceneState(string sceneName,SceneStateController controller)
     {
         mSceneName = sceneName;
         mController = controller;
     }

     public string SceneName
     {
        get { return mSceneName;  }
     }
    /// <summary>
    /// 每次进入到这个状态的时候调用
    /// </summary>
     public virtual void StateStart()
     {
         
     }

     public virtual void StateEnd()
     {
         
     }
     public virtual void StateUpdate()
     {
         
     }
 }

