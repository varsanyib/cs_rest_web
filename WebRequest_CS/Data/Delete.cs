using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRequest_CS.Model;

namespace WebRequest_CS.Data
{
    public class Delete
    {
        public static async Task<Answer> Request(string apiUrl, Dictionary<string, string> headers)
        {
            Answer answer = new Answer();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                    answer.Response = await client.DeleteAsync(apiUrl);
                    answer.Result = JObject.Parse(await answer.Response.Content.ReadAsStringAsync());
                }
                catch (HttpRequestException rex)
                {
                    answer.InternalErrorMessage = rex.Message;

                }
            }
            return answer;
        }
    }
}
