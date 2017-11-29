using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierKilledObserverArchievement : IGameEventObserver
{

	private AchievementSystem mArchSystem;
	public SoldierKilledObserverArchievement(AchievementSystem system){
		mArchSystem = system;
	}
public override void SetSubject(IGameEventSubject sub)
    {
       
    }

    public override void Update()
    {
        mArchSystem.AddSoldierKilledCount();
    }
}
