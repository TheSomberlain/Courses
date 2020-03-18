using System;
using System.Collections.Generic;
using System.Text;

namespace MyHashSetImplement
{
    public class OnAddObserver :Observer
    {
        private MyHashset<int> _observable;
        private List<string> addLog;
        public OnAddObserver(int age, string name, MyHashset<int> hashset) : base(age,name)
        {
            _observable = hashset;
            addLog = new List<string>();
        }
        public override void Subscribe()
        {
            _observable.onAdded += OnAdd; 
        }

        public override void Unsubscribe()
        {
            _observable.onAdded -= OnAdd;  
        }
        private void OnAdd(object sender, EventArgs e)
        {
            addLog.Add("Added new item");
            Console.WriteLine("HashSet has been modified");
      }
        public override void printLog()
        {
            foreach(string s in addLog)
            {
                Console.WriteLine(s);
            }
        }
    }
}
