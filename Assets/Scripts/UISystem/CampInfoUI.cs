using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
  public  class CampInfoUI:IBaseUI
    {
    private Image mCampIcon;
    private Text mCampName;
    private Text mCampLevel;
    private Button mCampUpgradeButton;
    private Button mWeaponUpgradeButton;
    private Button mTrainButton;

    private Button mCancelTrainButton;
    private Text mAliveCount;
    private Text mTrainCount;
    private Text mTrainTime;
    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "CampInfoUI");
        mCampIcon = UITool.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UITool.FindChild<Text>(mRootUI, "CampName");
        mCampLevel = UITool.FindChild<Text>(mRootUI, "CampLv");
        mCampUpgradeButton = UITool.FindChild<Button>(mRootUI, "CampUpgradeButton");
        mWeaponUpgradeButton = UITool.FindChild<Button>(mRootUI, "WeaponUpgradeButton");
        mTrainButton = UITool.FindChild<Button>(mRootUI, "TrainButton");
        mCancelTrainButton = UITool.FindChild<Button>(mRootUI, "CancelTrainButton");
        mAliveCount = UITool.FindChild<Text>(mRootUI, "AliveCount");
        mTrainCount = UITool.FindChild<Text>(mRootUI, "TrainCount");
        mTrainTime = UITool.FindChild<Text>(mRootUI, "TrainTime");
    }
}

