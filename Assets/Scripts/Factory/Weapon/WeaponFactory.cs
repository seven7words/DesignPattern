using System;
using System.Collections.Generic;
using UnityEngine;
public class WeaponFactory:IWeaponFactory
{
    public IWeapon CreateWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;
        string assetName = "";

        
        switch (weaponType)
        {
            case WeaponType.Gun:
                assetName = "WeaponGun";
                weapon = new WeaponGun(20,5, LoadWeaponGO(assetName));
                break;
            case WeaponType.Rifle:
                assetName = "WeaponRifle";
                weapon = new WeaponRifle(30, 7, LoadWeaponGO(assetName));
               
                break;
            case WeaponType.Rocket:
                assetName = "WeaponRocket";
                weapon = new WeaponRocket(40, 8, LoadWeaponGO(assetName));
               
                break;
        }
        return weapon;
    }

    private GameObject LoadWeaponGO(string assetName)
    {
        IAssetFactory factory = new ResourcesAssetFactory();
        GameObject weaponGO = factory.LoadWeapon(assetName);
        return weaponGO;
    }
}