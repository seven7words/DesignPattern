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
    private Text mWeaponLv;
    private Icamp mCamp;
    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        
        mRootUI = UnityTool.FindChild(canvas, "CampInfoUI");
        Debug.Log(mRootUI);
        mCampIcon = UITool.FindChild<Image>(mRootUI, "CampIcon");
        Debug.Log(mCampIcon);
        mCampName = UITool.FindChild<Text>(mRootUI, "CampName");
        mCampLevel = UITool.FindChild<Text>(mRootUI, "CampLv");
        mCampUpgradeButton = UITool.FindChild<Button>(mRootUI, "CampUpgradeButton");
        mWeaponUpgradeButton = UITool.FindChild<Button>(mRootUI, "WeaponUpgradeButton");
        mTrainButton = UITool.FindChild<Button>(mRootUI, "TrainButton");
        mCancelTrainButton = UITool.FindChild<Button>(mRootUI, "CancelTrainButton");
        mAliveCount = UITool.FindChild<Text>(mRootUI, "AliveCount");
        mTrainCount = UITool.FindChild<Text>(mRootUI, "TrainingCount");
        mTrainTime = UITool.FindChild<Text>(mRootUI, "TrainTime");
        mWeaponLv = UITool.FindChild<Text>(mRootUI,"WeaponLv");
        Hide();
    }
    public void ShowCampInfo(Icamp camp){
        Show();
        mCamp = camp;
        mCampIcon.sprite = FactoryManager.AssetFactory.LoadSprite(camp.iconSprite);
        mCampName.text = camp.name;
        mCampLevel.text = camp.lv.ToString();
        ShowWeaponLevel(camp.WeaponType);
    }
    void ShowWeaponLevel(WeaponType weaponType){
        switch(weaponType){
            case WeaponType.Gun:
                mWeaponLv.text = "短枪";
            break;
            case WeaponType.Rifle:
                mWeaponLv.text = "长枪";
            break;
            case WeaponType.Rocket:
                mWeaponLv.text = "火箭";
            break;
            default:
            break;
        }
    }
}

