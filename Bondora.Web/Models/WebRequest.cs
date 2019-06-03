using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Bondora.Web.Models
{
    public class WebRequest
    {
        private static IHttpClientFactory httpClientFactory;

        public WebRequest(IHttpClientFactory _httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
        }

        public static string SendWebRequest(string url, string method, string parametersJson = null)
        {
            var requestTime = DateTime.Now;
            string result = null;
            HttpClient httpClient = null;
            try
            {
                using (httpClient = httpClientFactory.CreateClient())
                {
                    int timeOutMiliSeconds = 100000;
                    
                    httpClient.Timeout = new TimeSpan(0, 0, 0, 0, timeOutMiliSeconds);
                    switch (method)
                    {
                        case "POST":
                            using (var responsePost = httpClient.PostAsync(url, new StringContent(parametersJson, Encoding.UTF8, "application/json")).GetAwaiter().GetResult())
                            {
                                result = responsePost.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                            }

                            break;
                        case "GET":
                            using (var responseGET = httpClient.GetAsync(url).GetAwaiter().GetResult())
                            {
                                result = responseGET.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                            }

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (WebException ex)
            {
                if (httpClient != null)
                {
                    httpClient.Dispose();
                }
            }
            
            return result;
        }
    }
}
