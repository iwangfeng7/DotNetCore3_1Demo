using System;
using System.Net.Http;

namespace DotNetCore3_1Utility
{
    public class WebApiExtend
    {
        public static string InvokeApi(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = HttpMethod.Get;
                message.RequestUri = new Uri(url);
                var result = httpClient.SendAsync(message).Result;
                string content = result.Content.ReadAsStringAsync().Result;
                return content;
            }
        }
    }
}