﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGameEventSubject  {
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
	private List<IGameEventObserver> mObservers = new List<IGameEventObserver>();
 	public void RegisterObserver(IGameEventObserver ob){
		 mObservers.Add(ob);
	 }
	 public void RemoveObserver(IGameEventObserver ob){
		 mObservers.Remove(ob);
	 }
	 public virtual void Notify(){
		 foreach(IGameEventObserver ob in mObservers){
			 ob.Update();
		 }
	 }
}
