using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T:MonoBehaviour {

	private T m_Instance;
	public T Instance{
		get{
			return m_Instance;
		}
	}
	private void Awake(){
		if(m_Instance==null){
			m_Instance = this as T;
		}else{
			Destroy(gameObject);
		}
	}
	private void OnDestroy(){
		if(this==m_Instance){
			m_Instance=null;
		}
	}
}
public abstract class Singleton<T> where T:class,new(){
	protected Singleton(){}
	private static T m_Instance;
	public static T Instance{
		get{
			if(m_Instance == null){
				m_Instance = new T();
			}
			return m_Instance;
		}
	}
	public static void Release(){
		m_Instance = null;
	}
} 
