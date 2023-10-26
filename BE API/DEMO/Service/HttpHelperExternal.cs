using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace DEMO.Service
{
    public static class HttpHelperExternal
    {
        static HttpClient client = new HttpClient();

        //static string BuildQueryWithParam(string url)
        //{
        //    var queryParams = context.HttpContext.Request.Query;
        //    var ub = new UriBuilder(url);
        //    var query = HttpUtility.ParseQueryString(ub.Query);
        //}

        public static async Task<T> GetTAsync<T>(string path)
        {
            try
            {
                var resultString = string.Empty;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    resultString = await response.Content.ReadAsStringAsync();
                }
                return JsonConvert.DeserializeObject<T>(resultString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
        }

    }

    internal class Department
    {
        public int DeptId { get; set; }
        public string DepartmentName { get; set; }
    }
}
