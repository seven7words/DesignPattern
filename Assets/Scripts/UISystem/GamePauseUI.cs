using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePauseUI :IBaseUI {
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
    private Text mCurrentStageLv;
    private Button mContinueButton;
    private Button mBackButton;
    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GamePauseUI");
        mCurrentStageLv = UITool.FindChild<Text>(mRootUI, "CurrentStageLv");
        mContinueButton = UITool.FindChild<Button>(mRootUI, "ContinueButton");
        mBackButton = UITool.FindChild<Button>(mRootUI, "BackButton");
       Hide();
    }
}
