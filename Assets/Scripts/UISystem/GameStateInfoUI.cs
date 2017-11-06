using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

  public  class GameStateInfoUI:IBaseUI
    {
    private List<GameObject> mHearts;
     private Text mSoldierCount;
    private Text mEnemyCount;
    private Text mCurrentStage;

        private Button mPauseButton;
    private GameObject mGameOverUI;
    private Button mBackButton;
    private Text mMessage;
    private Slider mEnergySlider;

        public override void Init()
        {
            base.Init();
            GameObject canvas = GameObject.Find("Canvas");
            mRootUI = UnityTool.FindChild(canvas, "GameStateUI");
        GameObject Heart1 = UITool.FindChild<GameObject>(mRootUI, "Heart1");
        GameObject Heart2 = UITool.FindChild<GameObject>(mRootUI, "Heart2");
        GameObject Heart3 = UITool.FindChild<GameObject>(mRootUI, "Heart3");
        mHearts.Add(Heart1);
        mHearts.Add(Heart2);
        mHearts.Add(Heart3);
        mSoldierCount = UITool.FindChild<Text>(mRootUI, "SoldierCount");
        mEnemyCount = UITool.FindChild<Text>(mRootUI, "mEnemyCount");
        mCurrentStage = UITool.FindChild<Text>(mRootUI, "StageCounter");
        mPauseButton = UITool.FindChild<Button>(mRootUI, "PauseButton");
        mGameOverUI = UITool.FindChild<GameObject>(mRootUI, "GameOver");
        mBackButton = UITool.FindChild<Button>(mRootUI, "BackButton");
        mMessage = UITool.FindChild<Text>(mRootUI, "Message");
        mEnergySlider = UITool.FindChild<Slider>(mRootUI, "EnergySlider");

        }
    }

