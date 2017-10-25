using System;
using System.Collections.Generic;
using UnityEngine;
public class WeaponFactory:IWeaponFactory
{
    public IWeapon CreateWeapon(WeaponType weaponType)
    {
        IAssetFactory factory = new ResourcesAssetFactory();
        WeaponBaseAttr baseAttr = FactoryManager.AttrFactory.GetWeaponBaseAttr(weaponType);
        IWeapon weapon = new IWeapon(baseAttr, factory.LoadWeapon(baseAttr.AssetName));

        return weapon;
    }

    private GameObject LoadWeaponGO(string assetName)
    {
        IAssetFactory factory = new ResourcesAssetFactory();
        GameObject weaponGO = factory.LoadWeapon(assetName);
        return weaponGO;
    }
}