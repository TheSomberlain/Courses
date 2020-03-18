using System;
using System.Collections.Generic;
using System.Text;

namespace MyHashSetImplement
{
    public class OnClearObserver : Observer
    {
        private MyHashset<int> _observable;
        private List<string> ClearLog;
        public OnClearObserver(int age, string name, MyHashset<int> hashset) : base(age, name)
        {
            _observable = hashset;
            ClearLog = new List<string>();
        }
        public override void Subscribe()
        {
            _observable.onClear += OnClear;
        }

        public override void Unsubscribe()
        {
            _observable.onClear -= OnClear;
        }
        private void OnClear(object sender, EventArgs e)
        {
            ClearLog.Add("HashSet cleared");
            Console.WriteLine("HashSet has been modified");
        }
        public override void printLog()
        {
            foreach (string s in ClearLog)
            {
                Console.WriteLine(s);
            }
        }
    }
}
