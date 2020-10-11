using HandsOnTest.Repository.Config;
using HandsOnTest.Repository.Entities;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HandsOnTest.Repository.Reposotories
{
    public class MasGlobalEmployeeTestRepository : IMasGlobalEmployeeTestRepository
    {
        private readonly MasGlobalEmployeeTestConfig _MasGlobalEmployeeTestConfig;
        private readonly IHttpClientFactory _HttpClientFactory;

        public MasGlobalEmployeeTestRepository(MasGlobalEmployeeTestConfig masGlobalEmployeeTestConfig,
                                                IHttpClientFactory httpClientFactory)
        {
            _MasGlobalEmployeeTestConfig = masGlobalEmployeeTestConfig;
            _HttpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            using var client = _HttpClientFactory.CreateClient();
            var retryPolicy = Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode != System.Net.HttpStatusCode.OK)
                                        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
            var response = await retryPolicy.ExecuteAsync(async () => await client.GetAsync(_MasGlobalEmployeeTestConfig.Url));
            response.EnsureSuccessStatusCode();
            var Employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(await response.Content.ReadAsStringAsync());
            return Employees;
        }
    }
}
