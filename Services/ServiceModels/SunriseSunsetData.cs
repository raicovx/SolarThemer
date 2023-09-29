using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarThemer.Services.Models
{
    public class SunriseSunsetData
    {
        //Times return as UTC
        public string sunrise { get; set; }
        public string sunset {  get; set; }
    }
}
