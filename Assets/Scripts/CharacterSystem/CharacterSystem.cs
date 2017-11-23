using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;


class CharacterSystem : IGameSystem
    {
    private List<ICharacter> mEnemys = new List<ICharacter>();
    private List<ICharacter> mSoldiers = new List<ICharacter>();

        public void AddEnemy(IEnemy enemy)
        {
            mEnemys.Add(enemy);
        }

        public void RemoveEnemy(IEnemy enemy)
        {
            mEnemys.Remove(enemy);
        }

        public void AddSoldier(ISoldier soldier)
        {
            mSoldiers.Add(soldier);
        }

        public void RemoveSoldier(ISoldier soldier)
        {
            mSoldiers.Remove(soldier);
        }

        public override void Update()
        {

            UpdateEnemy();
            UpdateSoldier();

            RemoveCharacterIsKilled(mEnemys);
             RemoveCharacterIsKilled(mSoldiers);
        }

        private void UpdateEnemy()
        {
        foreach (IEnemy enemy in mEnemys)
        {
            enemy.Update();
            enemy.UpdateFSMAI(mSoldiers);
        }
    }

        private void UpdateSoldier()
        {
        foreach (ISoldier soldier in mSoldiers)
        {
            soldier.Update();
            soldier.UpdateFSMAI(mEnemys);
        }
    }
    private void RemoveCharacterIsKilled(List<ICharacter> characters){
        List<ICharacter> canDestroy = new List<ICharacter>();
        foreach(ICharacter character in characters){
            if(character.CanDestroy){
                canDestroy.Add(character);
            }
        }
        foreach(ICharacter character in canDestroy){
            character.Release();
            characters.Remove(character);
        }
    }
    }

