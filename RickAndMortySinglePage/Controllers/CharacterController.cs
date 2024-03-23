using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RickAndMortySinglePage.Models;
using System.Text.Json.Serialization;

namespace RickAndMortySinglePage.Controllers
{
    public class CharacterController : Controller
    {
        private readonly IHttpClientFactory clientFactory;

        public CharacterController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page = 1, string query = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://rickandmortyapi.com/api/character?page={page}&name={query}");
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStram = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<CharacterResponse>(responseStram);
                return View(model);
            }
            else
            {
                return View(new CharacterResponse { Results = new List<Character>() });
            }
        
        }
        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://rickandmortyapi.com/api/character/{id}");
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request );
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Character>(responseStream);
                return View(model);
            }
            else
            {
                return View(new Character());
            }
        }
    }
}
