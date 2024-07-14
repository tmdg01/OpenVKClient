using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class ApiClient
{
    private const string BaseUrl = "https://ovk.to/method/";
    private string accessToken;

    public async Task<bool> AuthorizeAsync(string username, string password)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"{BaseUrl}token?username={Uri.EscapeDataString(username)}&password={Uri.EscapeDataString(password)}&grant_type=password");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(content);
                accessToken = json["access_token"].ToString();
                return true;
            }
            return false;
        }
    }

    public async Task<JArray> GetNewsfeedAsync()
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"{BaseUrl}newsfeed.get?access_token={accessToken}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(content);
                return json["response"]["items"] as JArray;
            }
            return null;
        }
    }
}