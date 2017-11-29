using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCaptive : ISoldier {
	private IEnemy mEnemy;
	public SoldierCaptive(IEnemy enemy){
		mEnemy = enemy;
		ICharacterAttr attr = new SoldierAttr(enemy.attr.Strategy,1,enemy.attr.baseAttr);
		this.attr = attr;

		this.gameObject = mEnemy.gameObject;
		this.Weapon = mEnemy.Weapon;
	}
	protected override void PlaySound(){
		//DO nothing
	}
	protected override void PlayEffect(){
		mEnemy.PlayEffect();
	}
}
