using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;


 public  abstract class ICharacter
 {


     protected ICharacterAttr mAttr;
     protected GameObject mGameObject;
     protected NavMeshAgent mNavMeshAgent;
     protected AudioSource mAudio;
     protected Animation mAnim;

     protected IWeapon mWeapon;

     public IWeapon Weapon
     {
         set { mWeapon = value; }
     }

     public float atkRange
     {
         get { return mWeapon.atkRange; }
     }
     public void Attack(ICharacter target)
     {
       mWeapon.Fire(target.Position);
        mGameObject.transform.LookAt(target.Position);
        PlayAnim("attack");
        target.UnderAttack(mWeapon.atk+mAttr.critValue);
     }

     public virtual void UnderAttack(int damage)
     {
         mAttr.TakeDamage(damage);
        //被攻击效果，，视效 只有敌人有

        //死亡 音效，视频特效，只有展示有

     }

     public void Killed()
     {
         //TODO
     }
     public abstract void UpdateFSMAI(List<ICharacter> targets);
     public void Update()
     {
         mWeapon.Update();
     }
     public void PlayAnim(string animName)
     {
         mAnim.CrossFade(animName);
     }

     public void MoveTo(Vector3 targetPosition)
     {
         mNavMeshAgent.SetDestination(targetPosition);
        PlayAnim("move");
     }
     protected void DoPlaySound(string soundName)
     {
         AudioClip clip = null;//TODO
         mAudio.clip = clip;
         mAudio.Play();
     }
     protected void DoPlayEffect(string effectName)
     {
         //加载特效 TODO
         GameObject effectGO;
         //控制销毁 TODO


     }

     public ICharacterAttr attr
     {
         set { mAttr = value; }
     }
    public Vector3 Position
     {
         get
         {
            if (mGameObject == null)
             {
                 Debug.LogError("gameObject为空");
                 return Vector3.zero;
             }
             return mGameObject.transform.position;

        }
    }
 
 }

