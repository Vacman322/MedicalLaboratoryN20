using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalLaboratoryN20.Util
{
    public class Time
    {
        public int Hours { get => (int)_totalMinutes / 60; }
        public int Minutes { get => (int)_totalMinutes; }

        private double _totalMinutes;

        public Time(double totalMinutes)
        {
            _totalMinutes = totalMinutes;
        }

        public bool NextMinutes()
        {
            if (_totalMinutes == 0)
                return false;

            _totalMinutes--;
            return true;
        }

        public override string ToString()
        {
            return $"{Hours,2:00}:{Minutes,2:00}";
        }
    }
}

