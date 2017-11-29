﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesAssetProxyFactory : IAssetFactory
{
    private ResourcesAssetFactory mAssetFactory = new ResourcesAssetFactory();
    private Dictionary<string,GameObject> mSoldiers = new Dictionary<string, GameObject>();
  private Dictionary<string,GameObject> mEnemies = new Dictionary<string, GameObject>();
 private Dictionary<string,GameObject> mWeapons = new Dictionary<string, GameObject>();

 private Dictionary<string,GameObject> mEffects = new Dictionary<string, GameObject>();
private Dictionary<string,AudioClip> mAudioClips = new Dictionary<string, AudioClip>();

private Dictionary<string,Sprite> mSprites = new Dictionary<string, Sprite>();

    public AudioClip LoadAudioClip(string name)
    {
        if(mAudioClips.ContainsKey(name)){
           return mAudioClips[name];
       }else{
            AudioClip audio = mAssetFactory.LoadAudioClip(name);
            mAudioClips.Add(name,audio);
            return audio;
       }
    }

    public GameObject LoadEffect(string name)
    {
       if(mEffects.ContainsKey(name)){
           return GameObject.Instantiate(mEffects[name]);
       }else{
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.EffectPath+name) as GameObject;
            mEffects.Add(name,asset);
            return GameObject.Instantiate(asset);
       }
    }

    public GameObject LoadEnemy(string name)
    {
        if(mEnemies.ContainsKey(name)){
           return GameObject.Instantiate(mEnemies[name]);
       }else{
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.EnemyPath+name) as GameObject;
            mEnemies.Add(name,asset);
            return GameObject.Instantiate(asset);
       }
    }

    public GameObject LoadSoldier(string name)
    {
       if(mSoldiers.ContainsKey(name)){
           return GameObject.Instantiate(mSoldiers[name]);
       }else{
            GameObject asset =   mAssetFactory.LoadAsset(ResourcesAssetFactory.SoldierPath+name) as GameObject;
            mSoldiers.Add(name,asset);
            return GameObject.Instantiate(asset);
       }
    }

    public Sprite LoadSprite(string name)
    {
       if(mSprites.ContainsKey(name)){
           return mSprites[name];
       }else{
            Sprite sprite = mAssetFactory.LoadSprite(name);
            mSprites.Add(name,sprite);
            return sprite;
       }
    }

    public GameObject LoadWeapon(string name)
    {
        if(mWeapons.ContainsKey(name)){
           return GameObject.Instantiate(mWeapons[name]);
       }else{
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.WeaponPath+name) as GameObject;
            mWeapons.Add(name,asset);
            return GameObject.Instantiate(asset);
       }
    }
}
