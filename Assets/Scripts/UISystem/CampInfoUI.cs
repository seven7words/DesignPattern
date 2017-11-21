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
        mTrainButton.onClick.AddListener(OnTrainClick);
        mCancelTrainButton.onClick.AddListener(OnCancelTrainClick);
        Hide();
    }
    public void ShowCampInfo(Icamp camp){
        Show();
        mCamp = camp;
        mCampIcon.sprite = FactoryManager.AssetFactory.LoadSprite(camp.iconSprite);
        mCampName.text = camp.name;
        mCampLevel.text = camp.lv.ToString();
        ShowWeaponLevel(camp.WeaponType);
        mTrainCount.text = camp.TrainCount.ToString();
        
        if(camp.TrainCount==0){
            //mCancelTrainButton.enabled = false;
            mCancelTrainButton.interactable = false;
        }

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
    public void OnTrainClick(){
        //能量是否足够 
        //TODO:
        mCamp.Train();
    }
    public void OnCancelTrainClick(){
        //TODO:回收能量
        mCamp.Cancel();
    }
    public  override  void Update(){
        base.Update();
        if(mCamp!=null)
            ShowTrainingInfo();
    }
    private void ShowTrainingInfo(){
        if(mCamp!=null){
            mTrainCount.text = mCamp.TrainCount.ToString();
            if(mCamp.TrainRemainingTime>0)
                mTrainTime.text = mCamp.TrainRemainingTime.ToString("0.00");
            if(mCamp.TrainCount==0){
                //mCancelTrainButton.enabled = false;
                mCancelTrainButton.interactable = false;
            }
            else{
                 mCancelTrainButton.interactable = true;
            }
        }
        
    }
}

