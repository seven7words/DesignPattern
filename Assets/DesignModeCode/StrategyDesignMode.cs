using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

  public  class StrategyDesignMode:MonoBehaviour
    {
        void Start()
        {
        StrategyContext context = new StrategyContext();
            context.strategy = new ConcreteStrategyA();
        context.Cal();
    }
    
    }

public class StrategyContext
{
    public IStrategy strategy;
    public void Cal()
    {
        strategy.Cal();
    }
}

public interface IStrategy
{
    void Cal();
}

public class ConcreteStrategyA : IStrategy
{
    public void Cal()
    {
        Debug.Log("使用A策略");
    }
}

