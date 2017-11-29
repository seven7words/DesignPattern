using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledObserverStageSystem : IGameEventObserver {
	private EnemyKilledSubject mSubject;
	private StageSystem mStageSystem;
	public EnemyKilledObserverStageSystem(StageSystem ss){
		mStageSystem = ss;
	}
    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as EnemyKilledSubject;

    }

    public override void Update()
    {
        mStageSystem.CountOfEnemyKilled = mSubject.KilledCount;
    }
}
