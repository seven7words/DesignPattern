using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 public abstract   class IGameSystem
 {
    #region 常量
    #endregion
    #region  属性

    #endregion
    #region 字段
        protected GameFacade mFacade;
    #endregion
    #region 事件
    #endregion
    #region 方法
        public virtual void Init() { 
            mFacade = GameFacade.Instance;
        }
        public virtual void Update() { }
        public virtual void Release() { }
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
    
   

 }

