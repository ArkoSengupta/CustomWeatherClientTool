using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Remoting.Contexts;
using System.Net;

namespace CustomWeatherClientTool
{
    internal class GetDataService
    {
        internal Coordinate GetCoordinate(string cityName)
        {
            Coordinate cityCo = new Coordinate();
            //Getting the entire dataset from json file
            string jsonText = File.ReadAllText(@"../../../in.json");
            List<CityData> Cities = JsonConvert.DeserializeObject<List<CityData>>(jsonText);

            //Getting the required city information
            foreach (CityData city in Cities) 
            {
                if (city.city.ToLower() == cityName.ToLower())
                {
                    cityCo.lat = city.lat;
                    cityCo.lng = city.lng;
                }

            }
            return cityCo;
        }

        internal WeatherData GetWeatherDetails(decimal lat, decimal lng)
        {
            //Forming the request URL
            string uri = "https://api.open-meteo.com/v1/forecast?latitude="+lat+"&longitude="+lng+"&current_weather=true";

            //Fetching data from API call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage clientResult = httpClient.GetAsync(uri).Result;
            string response = clientResult.Content.ReadAsStringAsync().Result;

            //Parsing the required weather information
            APIData responseData = JsonConvert.DeserializeObject<APIData>(response);
            WeatherData weather = responseData.current_weather;

            return weather;
        }
    }
}
