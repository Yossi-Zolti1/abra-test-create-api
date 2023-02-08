
using Abra_test.Domain;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Web;
//using Newtonsoft.Json;
//using System.Text.Json;

namespace Abra_test.Services.ApiRandomUserService
{
    public class UsersService : IUsersService
    {
        private readonly ILogger<UsersService> _logger;

        private static string UserGenUrl = "https://randomuser.me/api/";
        public UsersService(ILogger<UsersService> logger)
        {
            _logger = logger;
        }
        public async Task<UserGenResponse.Result> GetUsersData(string gender)
        {
            var url = $"{UserGenUrl}?results=10&gender={gender}";
            return await GetDataFromApiByUrl(url);
           
        }
        public async Task<List<string>> GetListOfMails()
        {
            var url = $"{UserGenUrl}?results=30";
            var result = await GetDataFromApiByUrl(url);
            var mails = result.Results.Select(user => user.Email).ToList();
            return mails;
        }
        public async Task<string> GetTheOldestUser()
        {
            var url = $"{UserGenUrl}?results=100";
            var result = await GetDataFromApiByUrl(url);
            var birthdayUser = result.Results.Select(user => user.Birthday).ToList();
            //This is always return null, beacouse is not value in the api 
            return "";
        }
        public async Task<string[]> GetMostPupalarCountry()
        {
            var url = $"{UserGenUrl}?results=5000";
            var result = await GetDataFromApiByUrl(url);
            var countries = result.Results.GroupBy(user => user.Location.Country);
            var maxCount = countries.Max(g => g.Count());
            var mostCommons = countries.Where(x => x.Count() == maxCount).Select(x => x.Key).ToArray();
            return mostCommons;
        }
        private static async Task<UserGenResponse.Result> GetDataFromApiByUrl(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UserGenResponse.Result>(responseBody);
            return result;
        }
    }
}
