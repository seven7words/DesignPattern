using System;
using System.Collections.Generic;
using UnityEngine;
public class BuilderDesignMode:MonoBehaviour
{
    void Start()
    {
        IBuilder fatBuilder = new FatBuilder();
        IBuilder thinBuilder = new ThinBuilder();
        Person fatPerson = Director.Construct(fatBuilder);
        Person thinPerson = Director.Construct(thinBuilder);
        fatPerson.Show();
    }
  
}
public class Person
{
    List<string> parts = new List<string>();

    public void AddPart(string part)
    {
        parts.Add(part);
    }

    public void Show()
    {
        foreach (string part in parts)
        {
            Debug.Log(part);
        }
    }

}

class Fat:Person
{
    
}

class Thin:Person
{
    

}

interface IBuilder
{
    void AddHead();
    void AddBody();
    void AddHand();
    void AddFeet();
    Person GetResult();
}

class FatBuilder : IBuilder
{
    private Person person;

    public FatBuilder()
    {
        person = new Fat();
    }
    public void AddHead()
    {
       person.AddPart("胖人头");
    }

    public void AddBody()
    {
        person.AddPart("胖人身体");
    }

    public void AddHand()
    {
        person.AddPart("胖人手");
    }

    public void AddFeet()
    {
        person.AddPart("胖人脚");
    }

    public Person GetResult()
    {
       person.Show();
        return person;
    }
}

class ThinBuilder : IBuilder
{
    private Person person;

    public ThinBuilder()
    {
        person = new Thin();
    }
    public void AddHead()
    {
        person.AddPart("瘦人头");
    }

    public void AddBody()
    {
        person.AddPart("瘦人身体");
    }

    public void AddHand()
    {
        person.AddPart("瘦人手");
    }

    public void AddFeet()
    {
        person.AddPart("瘦人脚");
    }

    public Person GetResult()
    {
        person.Show();
        return person;
    }
}

class Director
{
    public static Person Construct(IBuilder builder)
    {
        builder.AddBody();
        builder.AddFeet();
        builder.AddHand();
        builder.AddHead();
        return builder.GetResult();
    }
}