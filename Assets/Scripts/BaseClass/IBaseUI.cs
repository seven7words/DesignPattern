using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

 public abstract   class IBaseUI
 {
    #region 常量
    #endregion
    #region  属性
    #endregion
    #region 字段
        protected GameFacade mFacade;
        public GameObject mRootUI;
    #endregion
    #region 事件
    #endregion
    #region 方法
        public virtual void Init() {
            mFacade = GameFacade.Instance;
        }
        public virtual void Update() { }
        public virtual void Release() { }
        protected void Show(){
            mRootUI.SetActive(true);
            
        }
        protected void Hide(){
            mRootUI.SetActive(false);
        }
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
    
     
 }

