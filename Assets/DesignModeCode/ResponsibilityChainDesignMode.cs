using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsibilityChainDesignMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		char problem = 'a';
		// switch(problem){
		// 	case 'a':
		// 	new DMHandlerA().Handle();
		// 	break;
		// 	case 'b':
		// 	new DMHandlerB().Handle();
		// 	break;
		// }
		DMHandlerA handlerA = new DMHandlerA();
		DMHandlerB handlerB = new DMHandlerB();
		handlerA.SetNextHandler(handlerB).SetNextHandler(handlerB);
		handlerA.Handle(problem);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
public abstract class IDMHandler{
	protected IDMHandler mNextHandler = null;
	public IDMHandler nextHandler{
		set{
			mNextHandler = value;
		}
	}
	public IDMHandler SetNextHandler(IDMHandler handler){
		mNextHandler = handler;
		return mNextHandler;
	}
	public virtual void Handle(char problem){

	}
}
class DMHandlerA:IDMHandler{
	public override void Handle(char problem){
		if (problem=='a'){
			Debug.Log("处理完了A问题");
		}else{
			if(mNextHandler!=null){
				mNextHandler.Handle(problem);
			}
		}
			
	}
}
class DMHandlerB:IDMHandler{
	public override void Handle(char problem){
		if (problem=='a'){
			Debug.Log("处理完了B问题");
		}else{
			if(mNextHandler!=null){
				mNextHandler.Handle(problem);
			}
		}
		
	}
}


