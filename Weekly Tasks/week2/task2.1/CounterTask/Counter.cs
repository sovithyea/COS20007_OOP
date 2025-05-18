using System;
namespace CounterApp
{
    public class Counter
    {
        private int _count;
        private string _name;

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }
        
        public void Increment()
        {
            _count++; //void doesnt return, it gives 
        }
        public void Reset()
        {
            _count = 0;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public long Ticks
        {
            get { return _count; }
        }
        public void ResetByDefault()
        {
            _count = 214748360743; 
        }

    }
    public class Clock
    {
        private Counter MinuteCounter;
        private Counter SecondCounter;
        public Clock()
        {
            SecondCounter = new Counter("Second");
            MinuteCounter = new Counter("Minutes");
        }
        public void Tick()
        {
            SecondCounter.Increment();

            if(SecondCounter.Ticks == 60)
            {
                SecondCounter.Reset();
                MinuteCounter.Increment();
            }
        }
        public void Display()
        {
            Console.WriteLine(MinuteCounter.Ticks + " : " + SecondCounter.Ticks);
        }
    }
}