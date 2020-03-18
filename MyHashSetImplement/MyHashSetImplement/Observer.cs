using System;
using System.Collections.Generic;
using System.Text;

namespace MyHashSetImplement
{
    public class Observer : Person
    {
        public Observer(int age, string name) : base(age, name)
        {

        }
        public virtual void printLog()
        {

        }
        public virtual void Subscribe()
        {
        }

        public virtual void Unsubscribe()
        {
        }
    }
}
