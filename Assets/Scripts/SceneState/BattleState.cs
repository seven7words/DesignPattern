using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleState : ISceneState
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
    public BattleState( SceneStateController controller) : base("03BattleScene", controller)
    {
       
    }
    //兵营，关卡，角色管理，行动力，成就系统
    private GameFacade mFacade;

    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }

    public override void StateEnd()
    {

        GameFacade.Instance.Release();
    }

    public override void StateUpdate()
    {
        if (GameFacade.Instance.isGameOver)
        {
            Controller.SetState(new MainMenuState(Controller));
        }
        GameFacade.Instance.Update();
    }
}

