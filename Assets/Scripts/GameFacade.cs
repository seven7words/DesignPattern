using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// 既有外观模式，也有中介者模式
/// </summary>
public  class GameFacade
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
    private static GameFacade _instance = new GameFacade();

    private bool mIsGameOver = false;

    public static GameFacade Instance { get { return _instance; } }

    public bool isGameOver { get { return mIsGameOver; } }
    private GameFacade()
    {
        
    }
    /// <summary>
    /// 关于中介者模式的具体调用
    /// </summary>

    #region MyRegion

    private AchievementSystem mAchievementSystem;
    private CampSystem mCampSystem;
    private CharacterSystem mCharacterSystem;
    private EnergySystem mEnergySystem;
    private GameEventSystem mGameEventSystem;
    private StageSystem mStageSystem;

    private CampInfoUI mCampInfoUi;
    private GamePauseUI mGamePauseUi;
    private GameStateInfoUI mGameStateInfoUi;
    private SoldierInfoUI mSoldierInfoUi;
    #endregion

        public void Init()
        {
         mAchievementSystem = new AchievementSystem();
        mCampSystem = new CampSystem();
        mCharacterSystem = new CharacterSystem();
        mEnergySystem = new EnergySystem();
        mGameEventSystem = new GameEventSystem();
        mStageSystem = new StageSystem();
        mCampInfoUi = new CampInfoUI();
        mGamePauseUi = new GamePauseUI();
        mSoldierInfoUi = new SoldierInfoUI();
        mGameStateInfoUi = new GameStateInfoUI();
        mAchievementSystem.Init();
        mCampSystem.Init();
        mCharacterSystem.Init();
        mEnergySystem.Init();
        mGameEventSystem.Init();
        mStageSystem.Init();
        mCampInfoUi.Init();
        mGamePauseUi.Init();
        mSoldierInfoUi.Init();
        mGameStateInfoUi.Init();
        LoadMemento();

        }

        public void Update()
        {
        mAchievementSystem.Update();
            mCampSystem.Update();
            mCharacterSystem.Update();
            mEnergySystem.Update();
            mGameEventSystem.Update();
            mStageSystem.Update();
            mCampInfoUi.Update();
            mGamePauseUi.Update();
            mSoldierInfoUi.Update();
            mGameStateInfoUi.Update();
    }

        public void Release()
        {
            mAchievementSystem.Release();
            mCampSystem.Release();
            mCharacterSystem.Release();
            mEnergySystem.Release();
            mGameEventSystem.Release();
            mStageSystem.Release();
            mCampInfoUi.Release();
            mGamePauseUi.Release();
            mSoldierInfoUi.Release();
            mGameStateInfoUi.Release();
            CreateMemento();

    }
    public Vector3 GetEnemyTargetPosition()
    {
        //TOFO
        return mStageSystem.TargetPosition;
    }
    public void ShowCampInfo(Icamp camp){
        mCampInfoUi.ShowCampInfo(camp);
    }
    public void AddSoldier(ISoldier soldier){
        mCharacterSystem.AddSoldier(soldier);

    }
    public void AddEnemy(IEnemy enemy){
        mCharacterSystem.AddEnemy(enemy);
    }
    public bool TakeEnergy(int value){
        return mEnergySystem.TakeEnergy(value);
    }
    public void ShowMsg(string msg){
        mGameStateInfoUi.ShowMsg(msg);
    }
    public void RecycleEnergy(int value){
        mEnergySystem.RecycleEnergy(value);
    }
    public void UpdateEnergySlider(int nowEnergy,int maxEnergy){
        mGameStateInfoUi.UpdateEnergySlider(nowEnergy,maxEnergy);
    }
    public void RegisterObserver(GameEventType eventType,IGameEventObserver observer){
        mGameEventSystem.RegisterObserver(eventType,observer);
    }
    public void RemoveObserver(GameEventType eventType,IGameEventObserver observer){
        mGameEventSystem.RemoveObserver(eventType,observer);
    }
    public void NotifySubject(GameEventType eventType){
        mGameEventSystem.NotifySubject(eventType);
    }
    public void CreateMemento(){
      AchievementMemento memento =  mAchievementSystem.CreateMemento();
      memento.SaveData();
    }
    public void LoadMemento(){
        AchievementMemento memento = new AchievementMemento();
        memento.LoadData();
        mAchievementSystem.SetMemento(memento);
    }
    public void RunVisitor(ICharacterVisitor visitor){
        mCharacterSystem.RunVisitor(visitor);
    }
    public void RemoveEnemy(IEnemy enemy){
        mCharacterSystem.RemoveEnemy(enemy);
    }
    }

