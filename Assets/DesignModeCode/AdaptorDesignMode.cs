using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptorDesignMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Adaptor adaptor = new Adaptor(new NewPlugin());
		adaptor.Request();

		StandardInterfact si = new StandardImplementA();
		si.Request();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
public interface StandardInterfact{
	void Request();
}
public class StandardImplementA : StandardInterfact
{
    public void Request()
    {
        LogManager.W("标准方法");
    }
}
public class Adaptor:StandardInterfact{
	private NewPlugin plugin;
	public Adaptor(NewPlugin p){
		plugin = p;
	}
	public void Request(){
		plugin.SpecficRequest();
	}
}
public class NewPlugin{
	public void SpecficRequest(){
		LogManager.W("特殊方法");
	}
}
