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

     }

     public void PlayAnim(string animName)
     {
         mAnim.CrossFade(animName);
     }

     public void MoveTo(Vector3 targetPosition)
     {
         mNavMeshAgent.SetDestination(targetPosition);
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

