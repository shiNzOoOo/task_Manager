using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TMS.Mvc.Models;

namespace TMS.Mvc.Controllers
{
    public class TasksController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public TasksController(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiUrl = config["ApiUrl"] ?? "http://localhost:5000/api/tasks";
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var tasks = JsonSerializer.Deserialize<IEnumerable<TaskViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(tasks);
                }
            }
            catch (Exception)
            {
                // In case API is down, just return empty list with error
                ViewBag.Error = "Could not connect to the API.";
            }

            return View(new List<TaskViewModel>());
        }
    }
}
