using System;

namespace ClockApp
{
    public class Clock
    {
        private Counter _hour;
        private Counter _min;
        private Counter _sec;
        private bool _isAM; // true = AM, false = PM

        public Clock()
        {
            _hour = new Counter("Hours");
            _min = new Counter("Minutes");
            _sec = new Counter("Seconds");
            _isAM = true;
        }

        public string GetTime()
        {
            string h = (_hour.Ticks == 0 ? 12 : _hour.Ticks).ToString("D2");
            string m = _min.Ticks.ToString("D2");
            string s = _sec.Ticks.ToString("D2");
            string period = _isAM ? "AM" : "PM";

            return $"{h}:{m}:{s} {period}";
        }

        public void Restart()
        {
            _hour.Reset();
            _min.Reset();
            _sec.Reset();
            _isAM = true;
        }

        public void Tick()
        {
            _sec.Increment();

            if (_sec.Ticks == 60)
            {
                _sec.Reset();
                _min.Increment();

                if (_min.Ticks == 60)
                {
                    _min.Reset();
                    _hour.Increment();

                    if (_hour.Ticks == 12)
                    {
                        _isAM = !_isAM;
                    }
                    else if (_hour.Ticks == 13)
                    {
                        _hour.Reset();
                        _hour.Increment();
                    }
                }
            }
        }
    }
}
