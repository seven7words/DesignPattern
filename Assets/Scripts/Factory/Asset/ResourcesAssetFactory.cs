using System;
using System.Collections.Generic;
using UnityEngine;
public class ResourcesAssetFactory:IAssetFactory
{
    public const string SoldierPath = "Characters/Soldier/";
    public const string EnemyPath = "Characters/Enemy/";
    public const string WeaponPath = "Weapons/";
    public const string EffectPath = "Effects/";
    public const string AudioPath = "Audios/";
    public const string SpritePath = "Sprites/";
    public GameObject LoadSoldier(string name)
    {
        return InstantiateGameObject(SoldierPath+ name);
    }

    public GameObject LoadEnemy(string name)
    {
        return InstantiateGameObject(EnemyPath + name);
    }

    public GameObject LoadWeapon(string name)
    {
        return InstantiateGameObject(WeaponPath + name);
    }

    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(EffectPath + name);
    }

    public AudioClip LoadAudioClip(string name)
    {
        return  Resources.Load(AudioPath+name,typeof(AudioClip)) as AudioClip;
       // return LoadAsset(AudioPath + name) as AudioClip;
    }

    public Sprite LoadSprite(string name)
    {
       return  Resources.Load(SpritePath+name,typeof(Sprite)) as Sprite;
        //return LoadAsset(SpritePath + name) as Sprite;
    }

    private GameObject InstantiateGameObject(string path)
    {
        GameObject go = Resources.Load(path) as GameObject;
        if (go == null)
        {
            Debug.LogError("无法加载资源"+path);
            return null;
        }
        return GameObject.Instantiate(go);

    }

    private UnityEngine.Object LoadAsset(string path)
    {
        UnityEngine.Object go = Resources.Load(path) ;
        if (go == null)
        {
            Debug.LogError("�޷�������Դ·��" + path);
            return null;
        }
        return go;

    }

}