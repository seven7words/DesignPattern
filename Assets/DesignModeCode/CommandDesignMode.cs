using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CommandDesignMode:MonoBehaviour{
    void Start(){
        DMInvoker invoker = new DMInvoker();
        ConcreteCommand1 cmd1 = new ConcreteCommand1(new DMReceive1());
        invoker.AddCommand(cmd1);
        invoker.ExecuteCommand();
    }
}
public class DMInvoker{
    private List<DMICommand> commands = new List<DMICommand>();
    public void AddCommand(DMICommand command){
        commands.Add(command);
    }
    public void ExecuteCommand(){
        foreach(DMICommand cmd in commands){
            cmd.Execute();
        }
        commands.Clear();
    }
}
public abstract class DMICommand{
    public abstract void Execute();

}
public class ConcreteCommand1 : DMICommand
{
    DMReceive1 receive111;
    public ConcreteCommand1(DMReceive1 receiver1){
        this.receive111 = receiver1;
    }
    public override void Execute()
    {
        receive111.Action("Command1");
    }
}
public class DMReceive1{
    public void Action(string cmd){
        Debug.Log("Receiver1执行了命令");
    }
}