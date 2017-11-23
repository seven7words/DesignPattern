using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverDesignMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// WeatherStation ws = new WeatherStation();
		// BillboardA a = new BillboardA();
		// BillboardB b = new BillboardB();
		// BillboardC c = new BillboardC();
		// ws.Updatea(a,b,c);
		ConcreteSubject1 sub1 = new ConcreteSubject1();
		ConcreteObserver1 ob1 = new ConcreteObserver1(sub1);
		sub1.RegisterObserver(ob1);
		sub1.SubjectState = "温度90";
		
	}
	
}
// class WeatherStation{
// 	public void Updatea(BillboardA a,BillboardB b,BillboardC c){
// 		a.Show();
// 		c.Show();
// 		b.Show();
// 	}
// }
// class BillboardA{
// 	public void Show(){
// 		Debug.Log("A");
// 	}
// }
// class BillboardB{
// 	public void Show(){
// 		Debug.Log("B");
// 	}
// }
// class BillboardC{
// 	public void Show(){
// 		Debug.Log("C");
// 	}
// }
public abstract class Subject{
	List<Observer> mObservers = new List<Observer>();
	public void RegisterObserver( Observer observer){
		mObservers.Add(observer);
	}
	public void RemoveObserver(Observer observer){
		mObservers.Remove(observer);
	}
	public void NotifyObserver(){
		foreach(Observer ob in mObservers){
			ob.Update();
		}
	}
}
public abstract class Observer{
	public abstract void Update();
}
public class ConcreteSubject1:Subject{
	public string mSubjectState;
	public string SubjectState{
		set{
			mSubjectState = value;
			NotifyObserver();
		}
		get{
			return mSubjectState;
		}
	}
}
public class ConcreteObserver1:Observer{
	public ConcreteSubject1 mSub;
	public ConcreteObserver1(ConcreteSubject1 co){
		mSub = co;
	}
	public override void Update(){
		Debug.Log(mSub.mSubjectState);
	}
}