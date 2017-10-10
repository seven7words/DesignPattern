using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class StartState : ISceneState
{
    public StartState(SceneStateController controller) : base("01StartScene", controller)
    {

    }

    private Image mLogo;
    private float mSmoothingSpeed = 1f;
    private float mWaitTime = 2f;
    private float mWaitTimer = 0;
    public override void StateStart()
    {
        base.StateStart();
        mLogo = GameObject.Find("Logo").GetComponent<Image>();
        mLogo.color = Color.black;
        
    }

    public override void StateUpdate()
    {
        mLogo.color = Color.Lerp(mLogo.color, Color.white, mSmoothingSpeed*Time.deltaTime);
        mWaitTime -= Time.deltaTime;
        if (mWaitTime <= 0)
        {
            Controller.SetState(new MainMenuState(Controller));
        }
    }
}

