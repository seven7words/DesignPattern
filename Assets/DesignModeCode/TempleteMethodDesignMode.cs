using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.DesignModeCode
{
 public   class TempleteMethodDesignMode:MonoBehaviour
    {
        void Start()
        {
            IPeople people = new SouthPeople();
            people.EatSomething();
        }
    }

    public abstract class IPeople
    {
        public void Eat()
        {
            
        }

        private void OrderFoods()
        {
            Debug.Log("点单");
        }

        public virtual void EatSomething()
        {
            
        }

        private void PayBill()
        {
            Debug.Log("买单");
        }
    }

    public class NorthPeople : IPeople
    {
        public override void EatSomething()
        {
            Debug.Log("吃面条");
        }
    }

    public class SouthPeople : IPeople
    {
        public override void EatSomething()
        {
           Debug.Log("rice");
        }
    }
}
