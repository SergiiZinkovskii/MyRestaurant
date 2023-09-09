using IdentityModel.Client;
using MailApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;

namespace MailApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public async Task<IActionResult> GetDeliveries()
        {
            // retrieve to IdentityServer
            var authClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await authClient.GetDiscoveryDocumentAsync("https://localhost:10001");
            var tokenResponse = await authClient.RequestClientCredentialsTokenAsync(
            new ClientCredentialsTokenRequest
            {
            Address = discoveryDocument.TokenEndpoint,
            ClientId = "client_id",
            ClientSecret = "client_secret",
            Scope = "DeliveryAPI"
            });




            // retrieve to Delivers
            var deliveriesClient = _httpClientFactory.CreateClient();
            deliveriesClient.SetBearerToken(tokenResponse.AccessToken);


            var response = await deliveriesClient.GetAsync("https://localhost:7129/site/secret");


            var message = await response.Content.ReadAsStringAsync();

            ViewBag.Message = message;
            return View();
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