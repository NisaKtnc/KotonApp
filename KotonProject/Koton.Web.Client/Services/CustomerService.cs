﻿using Koton.Business.DTO_s;
using Koton.Entities.Models;
using Koton.Web.Client.Extensions;
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

        public async Task<Customer> AddCustomer(CustomerDto customerDto)
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.PostAsJsonAsync<CustomerDto>("Customer/Register", customerDto)).Content;

            var result = await content.ReadAsStreamAsync();
            return await result.DeserializeCustom<Customer>();

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

        public async Task<LoginModelDto> LoginAsync(LoginModelDto loginModel)
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.PostAsJsonAsync<LoginModelDto>("Customer/Login",loginModel)).Content;

            var result = await content.ReadAsStreamAsync();
            return await result.DeserializeCustom<LoginModelDto>();
        }


 
    }
}

