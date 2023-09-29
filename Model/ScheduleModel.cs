using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarThemer.Model
{
    public static class ScheduleModel
    {
        public static DateTime? Sunrise { get; set; }
        public static DateTime? Sunset { get; set; }
        public static DateOnly? CurrentDate { get; set; }
    }
}
