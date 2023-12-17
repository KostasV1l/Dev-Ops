using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelDev.Models;
using Contentful.Core;
using Contentful.Core.Search;

namespace TravelDev.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IContentfulClient _client;

        public HomeController(ILogger<HomeController> logger, IContentfulClient client)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string searchQuery = "")
        {
            IEnumerable<TravelAgency> Travels;

            // Use the Content Type ID 'travelAgency'
            var queryBuilder = QueryBuilder<TravelAgency>.New.ContentTypeIs("travelAgency").Include(2);

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                // Assuming you want to search by 'title'
                // Note: Adjust the field name if you're searching by a different field
                queryBuilder = queryBuilder.FieldEquals("fields.title", searchQuery);
            }

            Travels = await _client.GetEntries(queryBuilder);

            return View(Travels);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}