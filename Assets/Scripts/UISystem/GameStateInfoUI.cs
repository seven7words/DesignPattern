using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

  public  class GameStateInfoUI:IBaseUI
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
    private List<GameObject> mHearts;
     private Text mSoldierCount;
    private Text mEnemyCount;
    private Text mCurrentStage;

        private Button mPauseButton;
    private GameObject mGameOverUI;
    private Button mBackButton;
    private Text mMessage;
    private Slider mEnergySlider;
    private Text mEnergyLabel;
    private float mMsgTimer = 0;
    private int mMsgTime = 2;
    private AliveCountVisitor mAliveCountVisitor = new AliveCountVisitor();
        public override void Init()
        {
            base.Init();
            GameObject canvas = GameObject.Find("Canvas");
            mRootUI = UnityTool.FindChild(canvas, "GameStateUI");
            GameObject Heart1 = UITool.FindChild<GameObject>(mRootUI, "Heart1");
            GameObject Heart2 = UITool.FindChild<GameObject>(mRootUI, "Heart2");
            GameObject Heart3 = UITool.FindChild<GameObject>(mRootUI, "Heart3");
            mHearts = new List<GameObject>();
            mHearts.Add(Heart1);
            mHearts.Add(Heart2);
            mHearts.Add(Heart3);
            mSoldierCount = UITool.FindChild<Text>(mRootUI, "SoldierCount");
            mEnemyCount = UITool.FindChild<Text>(mRootUI, "EnemyCount");
            mCurrentStage = UITool.FindChild<Text>(mRootUI, "StageCounter");
            mPauseButton = UITool.FindChild<Button>(mRootUI, "PauseButton");
           // mGameOverUI = GameObject.Find("Canvas/GameStateUI/GameOver");
            mGameOverUI = UnityTool.FindChild(mRootUI,"GameOver");
            mBackButton = UITool.FindChild<Button>(mRootUI, "BackButton");
            mMessage = UITool.FindChild<Text>(mRootUI, "Message");
            mEnergySlider = UITool.FindChild<Slider>(mRootUI, "EnergySlider");
            mEnergyLabel = UITool.FindChild<Text>(mRootUI, "EnergyLabel");
            mMessage.text = "";
            mGameOverUI.SetActive(false);
        }
        public void ShowMsg(string msg){
            mMessage.text = msg;
            mMsgTimer = mMsgTime;
        }
        public override void Update(){
            base.Update();
            UpdateAliveCount();
            if(mMsgTimer>0){
                mMsgTimer-=Time.deltaTime;
                if(mMsgTimer<=0){
                    Debug.Log(mMessage.text);
                    mMessage.text = "";
                }
            }
        }
        public void UpdateEnergySlider(int nowEnergy,int maxEnergy){
            mEnergySlider.value =(float)nowEnergy/maxEnergy;
            mEnergyLabel.text = nowEnergy+"/"+maxEnergy;
        }
        public void UpdateAliveCount(){
            mAliveCountVisitor.Reset();
            mFacade.RunVisitor(mAliveCountVisitor);
            mSoldierCount.text = mAliveCountVisitor.soldierCount.ToString();
            mEnemyCount.text = mAliveCountVisitor.enemyCount.ToString();
        }
    }

