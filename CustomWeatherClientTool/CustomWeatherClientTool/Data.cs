using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomWeatherClientTool
{
    public struct Coordinate
    {
        public decimal? lat;
        public decimal? lng;
    }
    internal class CityData
    {
        public string city { get; set; }
        public Decimal? lat { get; set; }
        public Decimal? lng { get; set; }
        public string country { get; set; }
        public string iso2 { get; set; }
        public string admin_name { get; set; }
        public string capital { get; set; }
        public int? population { get; set; }
        public int? population_proper { get; set; }
    }

    internal class APIData
    {
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public double? generationtime_ms { get; set; }
        public int? utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public float? elevation { get; set; }
        public WeatherData current_weather { get; set; }
    }

    internal class WeatherData
    {
        public float? temperature { get; set; }
        public float? windspeed { get; set; }
        public float? winddirection { get; set; }
        public int? weathercode { get; set; }
        public DateTime? time { get; set; }
    }
}
