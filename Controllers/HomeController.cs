using DATAGOV_API_INTRO_8.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DATAGOV_API_INTRO_8.Controllers
{
    public class HomeController : Controller
    {
        // In-memory storage for parks data
        private static List<Park> ParksList = new List<Park>();

        private readonly HttpClient _httpClient;

        // API URL and API Key
        static string BASE_URL = "https://developer.nps.gov/api/v1";
        static string API_KEY = "mdBybOievMdeX3eYSC0MhFu3U7xRV18xHAPG04qb"; // API key

        public HomeController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            if (ParksList.Count == 0) // Only fetch if the list is empty
            {
                string apiPath = $"{BASE_URL}/parks?limit=20&api_key={API_KEY}";

                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(apiPath);

                    if (response.IsSuccessStatusCode)
                    {
                        string parksData = await response.Content.ReadAsStringAsync();
                        Parks parks = JsonConvert.DeserializeObject<Parks>(parksData);

                        if (parks != null && parks.data != null)
                        {
                            ParksList.AddRange(parks.data); // Store the data in memory
                        }
                    }
                }
                catch (Exception e)
                {
                    // Handle exceptions (e.g., log them)
                    Console.WriteLine(e.Message);
                }
            }

            // Pass the in-memory data to the view
            return View(ParksList);
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
