using Microsoft.AspNetCore.Mvc;
using CryptoQuotesApp.Models;
using Newtonsoft.Json.Linq;

namespace CryptoQuotesApp.Controllers
{
    public class CryptoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // Using your FastForex API key
        private const string FASTFOREX_API_KEY = "f42808801c-d720b61889-t7q8sg";

        public CryptoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string cryptoCode)
        {
            if (string.IsNullOrWhiteSpace(cryptoCode))
                return View();

            cryptoCode = cryptoCode.ToUpper();
            var client = _httpClientFactory.CreateClient();

            // ----------------------------
            // 1️⃣ Hardcoded USD prices for demo
            // ----------------------------
            decimal usdPrice = cryptoCode switch
            {
                "BTC" => 43000m,
                "ETH" => 3200m,
                "LTC" => 150m,
                _ => 100m // default for unknown crypto
            };

            // ----------------------------
            // 2️⃣ FastForex API call
            // ----------------------------
            JObject rates;

            try
            {
                var exchangeResponse = await client.GetStringAsync(
                    $"https://api.fastforex.io/fetch-all?api_key={FASTFOREX_API_KEY}");

                var exchangeJson = JObject.Parse(exchangeResponse);
                rates = exchangeJson["results"] as JObject
                        ?? throw new Exception("Exchange rates not found");
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Error = "Error fetching exchange rates: " + ex.Message;
                return View();
            }

            // ----------------------------
            // 3️⃣ Build ViewModel
            // ----------------------------
            var model = new CryptoQuoteViewModel
            {
                CryptoCode = cryptoCode,
                USD = usdPrice,
                EUR = usdPrice * rates["EUR"]!.Value<decimal>(),
                BRL = usdPrice * rates["BRL"]!.Value<decimal>(),
                GBP = usdPrice * rates["GBP"]!.Value<decimal>(),
                AUD = usdPrice * rates["AUD"]!.Value<decimal>()
            };

            return View(model);
        }
    }
}
