using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomentoDesignMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Originator originator = new Originator();
		// originator.SetState("State1");
		// originator.ShowState();

		// Memento memento = originator.CreateMemento();//创建快照
		// originator.SetState("State2");
		// originator.ShowState();
		// originator.SetMemento(memento);
		// originator.ShowState();
		CareTaker careTaker = new CareTaker();
		Originator originator = new Originator();
		originator.SetState("state1");
		originator.ShowState();
		careTaker.AddMemento("v1.0",originator.CreateMemento());

		originator.SetState("state2");
		originator.ShowState();
		careTaker.AddMemento("v2.0",originator.CreateMemento());

		originator.SetState("state3");
		originator.ShowState();
		careTaker.AddMemento("v3.0",originator.CreateMemento());
		originator.SetMemento(careTaker.GetMemento("v2.0"));
		originator.ShowState();
		originator.SetMemento(careTaker.GetMemento("v1.0"));
		originator.ShowState();

	}
	
	
}
class Originator{
	private string mState;
	public void SetState(string state){
		mState = state;
	}
	public void ShowState(){
		Debug.Log("Orginarot state"+mState);
	}
	public Memento CreateMemento(){
		Memento memento = new Memento();
		memento.SetState(mState);
		return memento;
	}
	public void SetMemento(Memento memento){
		SetState(memento.GetState());
	}
}
class Memento{
	private string mState;
	public void SetState(string state){
		mState = state;
	}
	public string GetState(){
		return mState;
	}
}
class CareTaker{
	Dictionary<string,Memento> mMementoDict = new Dictionary<string,Memento>();
	public void AddMemento(string version,Memento memento){
		mMementoDict.Add(version,memento);
	}
	public Memento GetMemento(string version){
		if(mMementoDict.ContainsKey(version)==false){
			LogManager.E("没有"+version);
		}
		return mMementoDict[version];
	}
}
