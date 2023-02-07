using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomWeatherClientTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter City Name: ");
            string city = Console.ReadLine();
            city = city.Trim(); 


            //Initializing service object
            GetDataService getData = new GetDataService();

            //Calling the service method
            Coordinate coordinate = getData.GetCoordinate(city);

            if (coordinate.lat != null && coordinate.lng != null)
            {
                WeatherData weather = getData.GetWeatherDetails(Convert.ToDecimal(coordinate.lat), Convert.ToDecimal(coordinate.lng));
                if(weather != null)
                {
                    //Printing Data
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("\nThe Coordinate of " + city + " is: " + coordinate.lat + ", " + coordinate.lng);
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("\nTemperature: " + weather.temperature + "\nWind Speed: " + weather.windspeed+ "\nWind Direction: "+weather.winddirection+"\nTime: "+weather.time);
                }
                else
                {
                    Console.WriteLine("Weather update for city "+city+" is not found");
                }
            }
            else
            {
                Console.WriteLine("Wrong city name or city name doesnot matches to any data.");
            }
            Console.ReadKey();
        }
    }
}
