using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledObserverArchievement : IGameEventObserver
{
	//private EnemyKilledSubject mSubject;
	private AchievementSystem mArchSystem;
	public EnemyKilledObserverArchievement(AchievementSystem system){
		mArchSystem = system;
	}
    public override void SetSubject(IGameEventSubject sub)
    {
        //mSubject = sub as EnemyKilledSubject;
		
    }

    public override void Update()
    {
        mArchSystem.AddEnemyKilledCount();
    }
}
