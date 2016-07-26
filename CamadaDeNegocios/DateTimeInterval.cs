using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeNegocios
{
    public class DateTimeInterval
    {
        public DateTime Start { get { return _Start; } }
        public DateTime End { get{return _End;} }

        private DateTime _Start;
        private DateTime _End;

        public DateTimeInterval(DateTime start, DateTime end)
        {
            _Start = start;
            _End = end;
        }

        public int GetMinutesInterval()
        {
            if (_Start < _End)
            {
                TimeSpan ts = _End - _Start;
                return ts.Minutes;
            }
            else return 0;
        }
    }
}
