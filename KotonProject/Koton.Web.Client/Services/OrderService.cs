using DocumentFormat.OpenXml.Wordprocessing;
using Koton.Business.DTO_s;
using Koton.Entities.Models;
using Koton.Web.Client.Extensions;

namespace Koton.Web.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public const string apiName = "kotonWebApi";

        public OrderService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.GetAsync("Order/GetAllOrders")).Content;

            var result = await content.ReadAsStreamAsync();
            var orders = await result.DeserializeCustom<IEnumerable<Order>>();
            return orders;
        }

        public async Task<Order> GetOrderById(int Id)
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.GetAsync($"Order/GetById?Id={Id}")).Content;

            var result = await content.ReadAsStreamAsync();
            var orders = await result.DeserializeCustom<Order>();
            return orders;
        }
    }
}
