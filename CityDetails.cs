using System;
using System.Collections.Generic;
using System.Text;

namespace TechAssignmentWeatherForecast2
{
    public class CityDetails
    {
        public string city { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
        public string country { get; set; }
        public string iso2 { get; set; }
        public string admin_name { get; set; }
        public string capital { get; set; }
        public string population { get; set; }
        public string population_proper { get; set; }
    }
}   