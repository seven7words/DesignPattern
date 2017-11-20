using UnityEngine;
using System.Collections;

public class SoldierCamp : Icamp
{
    const int MAX_LV = 4;
    private int mLv = 1;
    private WeaponType mWeaponType = WeaponType.Gun;
    public SoldierCamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position, float trainTime, WeaponType weaponType=WeaponType.Gun, int lv=1):base(gameObject,name,icon,soldierType,position,trainTime){
            mLv = lv;
        mWeaponType = weaponType;
    }
    public override int lv{
        get{
            return mLv;
        }
    }
    public override WeaponType WeaponType{
        get{
            return mWeaponType;
        }
    }
    public override void Train(){
        //添加训练命令
        TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType,mWeaponType,mPosition,mLv);
        mCommands.Add(cmd);
    }
}
