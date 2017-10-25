using System;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
public class CompositeDesignMode:MonoBehaviour
{
    void Start()
    {
        DMComponent root = new DMComposite("Root");
        DMLeaf leaf1 = new DMLeaf("GameObject (2)");
        DMLeaf leaf2 = new DMLeaf("GameObject (3)");
        DMComposite gameObject1 = new DMComposite("GameObject (1)");
        root.AddChild(gameObject1);
        root.AddChild(leaf2);
        gameObject1.AddChild(leaf1);
    }
    //…Ó∂»
    private void ReadComposite(DMComponent com)
    {
        Debug.Log(com.Name);
        List<DMComponent> children = com.children;
        if(children==null||children.Count==0)
            return;
        foreach (DMComponent child in children)
        {
            ReadComposite(child);
        }
    }
}

public abstract class DMComponent
{
    protected string mName;
    public List<DMComponent> children { get { return mChildren; } }
    public string Name
    {
        get { return mName; }
    }

    public DMComponent(string name)
    {
        mName = name;
        mChildren = new List<DMComponent>();
    }

    protected List<DMComponent> mChildren;
    public abstract void AddChild(DMComponent c);
    public abstract void RemoveChild(DMComponent c);
    public abstract DMComponent GetChild(int index);

}

public class DMLeaf : DMComponent
{
    public DMLeaf(string name) : base(name)
    {
    }

    public override void AddChild(DMComponent c)
    {
        return;
    }

    public override void RemoveChild(DMComponent c)
    {
       return;
    }

    public override DMComponent GetChild(int index)
    {
        return null;
    }
}

public class DMComposite : DMComponent
{
    public DMComposite(string name) : base(name)
    {
    }

    public override void AddChild(DMComponent c)
    {
        mChildren.Add(c);
    }

    public override void RemoveChild(DMComponent c)
    {
        mChildren.Remove(c);
    }

    public override DMComponent GetChild(int index)
    {
     return   mChildren[index];
    }
}