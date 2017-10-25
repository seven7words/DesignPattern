using System;
using System.Collections.Generic;
using UnityEngine;
public class SoldierFactory:ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) 
    {
        ISoldier soldier = new ISoldier();
       
       ICharacterBuilder builder = new SoldierBuilder(soldier,typeof(T),weaponType,spawnPosition,lv);
        return CharacterBuilderDirector.Construct(builder);
    }
    
}