using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePauseUI :IBaseUI {
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
       
    }
}
