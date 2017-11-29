using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageObserverArchievement : IGameEventObserver
{
	private NewStageSubject mSubject;
	private AchievementSystem mArchSystem;
	public NewStageObserverArchievement(AchievementSystem system){
		mArchSystem = system;
	}
    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as NewStageSubject;
		return;
    }

    public override void Update()
    {
        mArchSystem.SetMaxStageLv(mSubject.StageCount);
    }
}
