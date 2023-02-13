using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechAssignmentWeatherForecast2
{
    public class Program
    {
        public  void Main()
        {
            try
            {
                Console.WriteLine("Please enter the city name:");
                string userInputCity = string.Empty;
                userInputCity = Console.ReadLine();
                string filePath = @"C:\Users\user\source\repos\TechAssignmentWeatherForecast2\JsonFile\CityDetails.json";
                string json = System.IO.File.ReadAllText(filePath);
                var cityDetails = JsonConvert.DeserializeObject<List<CityDetails>>(json);

                var cityDetail = from c in cityDetails
                                 where c.city.ToUpper() == userInputCity.ToUpper()
                                 select c;
                var cityDetailForApi = cityDetail.FirstOrDefault();

                if (cityDetailForApi != null)
                {

                     CallWatherForecastApi(cityDetailForApi.city, cityDetailForApi.lat, cityDetailForApi.lng);
                }
                else
                {
                   
                    Console.WriteLine("The city you have entered not found in DB/Dataset");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+"\n");
                Console.WriteLine(ex.StackTrace.ToString());
                Console.ReadKey();
            }
        }
        
        public  void CallWatherForecastApi(string city, decimal lat, decimal lng)
        {
            ApiResponse result = new ApiResponse();
            try
            {
                var client = new RestClient();
                var request = new RestRequest("https://api.open-meteo.com/v1/forecast?" + "latitude=" + lat + "&" + "longitude=" + lng + "&current_weather=true");
                var response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string rawResponse = response.Content;
                    result = JsonConvert.DeserializeObject<ApiResponse>(rawResponse);
                    if (result != null)
                    {
                        Console.WriteLine("Weather information of city " + city.ToUpper() + ":\n");
                        Console.WriteLine("Latitude:" + result.latitude + "\n");
                        Console.WriteLine("Longitude:" + result.longitude + "\n");
                        Console.WriteLine("Temperature:" + result.current_weather.temperature + "\n");
                        Console.WriteLine("Wind Speed:" + result.current_weather.windspeed + "\n");
                        Console.WriteLine("Wind Direction:" + result.current_weather.winddirection + "\n");
                        Console.WriteLine("Weather Code:" + result.current_weather.weathercode + "\n");
                        Console.ReadKey();
                    }

                }
                //throw new NotImplementedException();
                else
                {
                    Console.WriteLine("Error while calling API");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
                Console.ReadKey();
            }
          //  return result;

        }

    }
}

