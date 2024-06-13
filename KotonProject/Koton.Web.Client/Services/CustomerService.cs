﻿using Koton.Business.DTO_s;
using Koton.Entities.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace Koton.Web.Client.Services
{
    public class CustomerService : ICustomerService
    {
        public const string apiName = "kotonWebApi";
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<Customer> AddCustomer(CustomerDto customerDto)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> DeleteCustomerById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerById(int Id)
        {
            throw new NotImplementedException();
        }
           
        public Task<Customer> UpdateCustomer(CustomerDto customerDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> LoginAsync(LoginModelDto loginModel)
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.GetAsync("Customer/LoginAsync")).Content;

            var result = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Customer>(result, options);
        }


 
    }
}
