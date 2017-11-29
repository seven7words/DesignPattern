using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
  public  class CampInfoUI:IBaseUI
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
    private Text mTrainButtonLabel;
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
        mTrainButtonLabel= UITool.FindChild<Text>(mRootUI,"TrainButtonLabel");
        mTrainButton.onClick.AddListener(OnTrainClick);
        mCancelTrainButton.onClick.AddListener(OnCancelTrainClick);
        mCampUpgradeButton.onClick.AddListener(OnCampUpgradeClick);
        mWeaponUpgradeButton.onClick.AddListener(OnWeaponUpgradeClick);
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
        mTrainButtonLabel.text = "训练\n"+mCamp.EnergyCostTrain+"点能量";
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
        int energy = mCamp.EnergyCostTrain;
        if(GameFacade.Instance.TakeEnergy(energy)){
            mCamp.Train();
        }else{
            mFacade.ShowMsg("能量不足，无法训练士兵");
        }
    }
    public void OnCancelTrainClick(){
        //回收能量
        mFacade.RecycleEnergy(mCamp.EnergyCostTrain);
        mCamp.Cancel();
    }
    public void OnCampUpgradeClick(){
        int energy = mCamp.EnergyCostCampUpgrade;
        if(energy<0){
            mFacade.ShowMsg("兵营已到最大等级，无法再进行升级");
            return;
        }
        if(mFacade.TakeEnergy(energy)){
             mCamp.UpgradeCamp();
            ShowCampInfo(mCamp);
        }else{
            mFacade.ShowMsg("升级兵营需要能量"+energy+"能量不足，请稍后进行升级");
        }
       
    }
    public void OnWeaponUpgradeClick(){
        int energy = mCamp.EnergyCostWeaponUpgrade;
        if(energy<0){
            mFacade.ShowMsg("武器已到最大等级，无法再进行升级");
            return;
        }
        if(mFacade.TakeEnergy(energy)){
            mCamp.UpgradeWeapon();
            ShowCampInfo(mCamp);
        }else{
            mFacade.ShowMsg("能量不足"+energy+"，请稍后进行升级");
        }
       
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

