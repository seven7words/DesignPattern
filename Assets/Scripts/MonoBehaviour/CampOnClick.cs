using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class CampOnClick:MonoBehaviour{
    private Icamp mCamp;
    public Icamp camp{
        set{
            mCamp = value;
        }
    }
    void OnMouseUpAsButton(){
        GameFacade.Instance.ShowCampInfo(mCamp);
    }
}