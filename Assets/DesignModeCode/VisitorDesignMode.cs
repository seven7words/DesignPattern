using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorDesignMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DMSphere sphere1 = new DMSphere();
		DMCylinder cylinder1 = new DMCylinder();
		DMCube cube1 = new DMCube();
		DMCube cube2 = new DMCube();
		DMShapeContainer container = new DMShapeContainer();
		container.AddShape(sphere1);
		container.AddShape(cylinder1);
		container.AddShape(cube1);
		container.AddShape(cube2);
		// int count = container.GetShapeCount();
		// int cubeCOunt = container.GetCubeCount();
		AmountVisitor amountVisitor = new AmountVisitor();
		container.RunVisitor(amountVisitor);
		int amount = amountVisitor.amount;
		CubeAmountVisitor cubeAmountVisitor = new CubeAmountVisitor();
		container.RunVisitor(cubeAmountVisitor);
		int cubeAmount = cubeAmountVisitor.amount;
	}
	
	
}
class DMShapeContainer{
	private List<IDMShape> mShapes = new List<IDMShape>();
	
	public void AddShape(IDMShape shape){
		mShapes.Add(shape);
	}
	public void RunVisitor(IDMShapeVisitor visitor){
		foreach(IDMShape shape in mShapes){
			shape.RunVisitor(visitor);
		}
	}
	// public int GetShapeCount(){
	// 	return mShapes.Count;
	// }
	// public int GetCubeCount(){
	// 	int count = 0;
	// 	foreach(IDMShape shape in mShapes){
	// 		if(shape.GetType()==typeof(DMCube)){
	// 			count++;
	// 		}
	// 	}
	// 	return count;
	// }
	// public int GetVolume(){
	// 	int temp = 0;
	// 	foreach(IDMShape shape in mShapes){
	// 		temp+=shape.GetVolume();
	// 	}
	// 	return temp;
	// }
}
public abstract class IDMShape{
	public abstract int GetVolume();
	public abstract void RunVisitor(IDMShapeVisitor visitor);
}
public class DMSphere : IDMShape
{
    public override int GetVolume()
    {
        return 30;
    }

    public override void RunVisitor(IDMShapeVisitor visitor)
    {
        visitor.VisitSphere(this);
    }
}
public class DMCylinder : IDMShape
{
    public override int GetVolume()
    {
         return 20;
    }

    public override void RunVisitor(IDMShapeVisitor visitor)
    {
        visitor.VisitCylinder(this);
    }
}
public class DMCube : IDMShape
{
    public override int GetVolume()
    {
         return 10;
    }

    public override void RunVisitor(IDMShapeVisitor visitor)
    {
       visitor.VisitCube(this);
    }
}
public abstract class IDMShapeVisitor{
	public	abstract void VisitSphere(DMSphere sphere);
	public	abstract void VisitCylinder(DMCylinder cylinder);
	public	abstract void VisitCube(DMCube cube);
}
public class AmountVisitor : IDMShapeVisitor
{
	public int amount = 0;
    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
         amount++;
    }

    public override void VisitSphere(DMSphere sphere)
    {
        amount++;
    }
}
public class CubeAmountVisitor : IDMShapeVisitor
{
	public int amount = 0;
    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
         return;
    }

    public override void VisitSphere(DMSphere sphere)
    {
        return;
    }
}