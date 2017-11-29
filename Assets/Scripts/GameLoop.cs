using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
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
    private SceneStateController controller = null;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	// Use this for initialization
	void Start () {
		controller = new SceneStateController();
        controller.SetState(new StartState(controller),false);
	}
	
	// Update is called once per frame
	void Update () {
		if(controller!=null)
			controller.StateUpdate();
	}
}
