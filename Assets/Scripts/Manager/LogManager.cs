using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoSingleton<MonoBehaviour> {
	 #region 常量
    #endregion
    #region  属性
    #endregion
    #region 字段
    #endregion
    #region 事件
    #endregion
    #region 方法
    #endregion
    #region Unity回调
    #endregion
    #region  事件回调
    #endregion
    #region 帮助方法
    #endregion
	const string PROMPT = "{0},{1}";
	public enum LogLevel{
		I,
		D,
		W,
		E,
	}
	public LogLevel setLevel = LogLevel.D;
	private static LogLevel m_Level = LogLevel.D;

	public static LogLevel logLevel{
		get{
			return m_Level;
		}
		private set{m_Level = value;}
	}
	private void Awake(){
		m_Level = setLevel;
	}
	static void Log(LogLevel level,string format,params object[] Args){
		if((int)m_Level<=1){
			Debug.LogFormat(PROMPT,level,string.Format(format,Args));
		}
	}
	// Update is called once per frame
	void Update () {
		if(logLevel!=setLevel){
			logLevel = setLevel;
		}
	}
	static void LogWarning(string format,params object[] Args){
		var l = LogLevel.W;
		if(logLevel<=l){
			Debug.LogFormat(PROMPT,l,string.Format(format,Args));
		}
	}
	static void LogError(string format,params object[] Args){
		var l = LogLevel.E;
		if(logLevel<=l){
			Debug.LogFormat(PROMPT,l,string.Format(format,Args));
		}
	}
	static public void D(string format,params object[] Args){
		Log(LogLevel.I,format,Args);
	}
	static public void W(string format,params object[] Args){
		LogWarning(format,Args);
	}
	static public void E(string format,params object[] Args){
		LogError(format,Args);
	}
	static public void Info(object message){
		if(logLevel<=LogLevel.I){
			Debug.Log(message);
		}
	}
	static public void Log(object message){
		if(logLevel<=LogLevel.D){
			Debug.Log(message);
		}
	}
	static public void LogWarning(object message){
		if(logLevel<=LogLevel.W){
			Debug.LogWarning(message);
		}
	}
	static public void LogError(object message){
		if(logLevel<=LogLevel.W){
			Debug.LogError(message);
		}
	}
}
