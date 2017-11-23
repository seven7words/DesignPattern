using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public enum GameEventType{
    Null,
    EnemyKilled,
    SoldierKilled,
    NewStage,
}
class GameEventSystem:IGameSystem
{
    private Dictionary<GameEventType,IGameEventSubject> mGameEvents = new Dictionary<GameEventType, IGameEventSubject>();
    public override void Init()
    {
        base.Init();
        InitGameEvents();
    }
    private void InitGameEvents(){
        mGameEvents.Add(GameEventType.EnemyKilled,new EnemyKilledSubject());
        mGameEvents.Add(GameEventType.SoldierKilled,new SoldierKilledSubject());
        mGameEvents.Add(GameEventType.NewStage,new NewStageSubject());
    }
    public void RegisterObserver(GameEventType eventType,IGameEventObserver observer){
        IGameEventSubject sub =GetGameEvent(eventType);
        if(sub==null) return;
       sub.RegisterObserver(observer);
       observer.SetSubject(sub);
    }
    public void RemoveObserver(GameEventType eventType,IGameEventObserver observer){
        IGameEventSubject sub =GetGameEvent(eventType);
        if(sub==null) return;
       sub.RemoveObserver(observer);
       observer.SetSubject(null);
    }
    private IGameEventSubject GetGameEvent(GameEventType eventType){
         if(mGameEvents.ContainsKey(eventType)==false){
           Debug.LogError("没有对应事件类型");
           return null;
       }
       IGameEventSubject sub = mGameEvents[eventType];
       return sub;
    }
    public void NotifySubject(GameEventType eventType){
         IGameEventSubject sub =GetGameEvent(eventType);
        if(sub==null) return;
        sub.Notify();
    }
    public void Update()
    {
        
    }

    public void Release()
    {
        
    }
}
