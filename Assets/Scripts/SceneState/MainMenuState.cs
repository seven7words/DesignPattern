using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuState : ISceneState
{
    public MainMenuState( SceneStateController controller) : base("02MainMenuScene", controller)
    {
       
    }

    public override void StateStart()
    {
       GameObject.Find("StartButton").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        Controller.SetState(new BattleState(Controller));
    }
}

