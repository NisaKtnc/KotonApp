﻿using Koton.Entities.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Koton.Web.Client.Services
{
    public class ColorService : IColorService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public const string apiName = "kotonWebApi";
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true,
           ReferenceHandler = ReferenceHandler.IgnoreCycles};
        
        public ColorService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Color>> GetAllColorAsync()
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.GetAsync("Color/GetAllColorAsync")).Content;

            var result = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Color>>(result, options);
        }
    }
}