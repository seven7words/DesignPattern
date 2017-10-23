using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 桥接模式
/// </summary>
 public   class BridgeDesignMode:MonoBehaviour
    {
        void Start()
        {
        //IRenderEngine renderEngine = new OpenGL();
        //Sphere1 sphere1 = new Sphere1(renderEngine);
        //    sphere1.Draw();
        //   // sphere1.DrawX();
        //Cube1 cube1 = new Cube1(renderEngine);
        //cube1.Draw();
        //    //cube1.DrawX();
        //Capsule1 capsule1 = new Capsule1(renderEngine);
        //capsule1.Draw();
        //   // capsule1.DrawX();
        ICharacter character = new SoldierCaptain();
        WeaponRifle rifle = new WeaponRifle();
            character.Weapon = new WeaponRifle();
        character.Attack(character);

        }
       

    }

public class IShape
{
    public string name;
    public IRenderEngine RenderEngine;


    public IShape(IRenderEngine renderEngine)
    {
        this.RenderEngine = renderEngine;
    }
    public void Draw()
    {
        RenderEngine.Draw(name);
    }
}

public abstract class IRenderEngine
{
    public abstract void Draw(string name);

}
public class Capsule1:IShape
{

    public Capsule1(IRenderEngine renderEngine) : base(renderEngine)
    {
        name = "Capsule1";
    }
    //public OpenGL openGL = new OpenGL();
    //public DirectXL Direct = new DirectXL();
    //public void Draw()
    //{
    //    openGL.Render(name);
    //}
    //public void DrawX()
    //{
    //    Direct.Render(name);
    //}
}
public class Sphere1:IShape
{
    public Sphere1(IRenderEngine renderEngine) : base(renderEngine)
    {
        name = "Sphere1";
    }
    //public string name = "Sphere";
    //public OpenGL openGL = new OpenGL();
    //public DirectXL Direct = new DirectXL();
    //public void Draw()
    //{
    //    openGL.Render(name);
    //}
    //public void DrawX()
    //{
    //    Direct.Render(name);
    //}

}
public class Cube1:IShape
{
    public Cube1(IRenderEngine renderEngine) : base(renderEngine)
    {
        name = "Cube1";
    }
    //public string name = "Cube1";
    //public OpenGL openGL = new OpenGL();
    //public DirectXL Direct = new DirectXL();
    //public void Draw()
    //{
    //    openGL.Render(name);
    //}
    //public void DrawX()
    //{
    //    Direct.Render(name);
    //}

}
public class OpenGL:IRenderEngine
{
    public void Render(string name)
    {
        Debug.Log("OpenGL绘制出来了"+name);
    }

    public override void Draw(string name)
    {
        Debug.Log("OpenGL绘制出来了" + name);
    }
}
public class DirectXL : IRenderEngine
{
    public void Render(string name)
    {
        Debug.Log("DirectXL绘制出来了" + name);
    }

    public override void Draw(string name)
    {
        Debug.Log("DirectXL绘制出来了" + name);
    }
}

public class SuperRender : IRenderEngine
{
    public override void Draw(string name)
    {
        Debug.Log("fsdf"+name);
    }
}