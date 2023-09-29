using SolarThemer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarThemer.Services
{
    public interface IDaytimeService
    {
        Task<SunriseSunsetData?> GetSolarScope();
    }
}
