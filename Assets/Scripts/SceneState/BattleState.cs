using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleState : ISceneState
{
    public BattleState( SceneStateController controller) : base("03BattleScene", controller)
    {
       
    }
    //兵营，关卡，角色管理，行动力，成就系统
    private GameFacade mFacade;

    public override void StateStart()
    {
        mFacade.Init();
    }

    public override void StateEnd()
    {
        mFacade.Release();
    }

    public override void StateUpdate()
    {
        if (mFacade.isGameOver)
        {
            Controller.SetState(new MainMenuState(Controller));
        }
        mFacade.Update();
    }
}

