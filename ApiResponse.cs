using System;
using System.Collections.Generic;
using System.Text;

namespace TechAssignmentWeatherForecast2
{
    public class ApiResponse
    {
        // public string status { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public decimal generationtime_ms { get; set; }
        public decimal utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public decimal elevation { get; set; }
        public current_weather current_weather { get; set; }

    }


    public class current_weather
    {
        public decimal temperature { get; set; }
        public decimal windspeed { get; set; }
        public decimal winddirection { get; set; }
        public decimal weathercode { get; set; }
        public string time { get; set; }

    }
}