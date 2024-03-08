using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WebRequest_CS.Data;
using WebRequest_CS.Model;

class Program
{
    static async Task Main(string[] args)
    {
        await Console.Out.WriteLineAsync("GET request: ");
        Answer todos = await Get.Request("http://localhost:3000/todo", new Dictionary<string, string>() { { "User-Agent", "MyTestApplication/1.0.0" } });
        await Console.Out.WriteLineAsync(todos.InternalError ? todos.InternalErrorMessage : "No internal errors!");
        if (!todos.InternalError) 
        { 
            await Console.Out.WriteLineAsync("\nServer sent headers:\n" + todos.Response?.Headers.ToString());
            await Console.Out.WriteLineAsync("\nStatusCode: " + todos.Response?.StatusCode + " (" + (int)todos.Response?.StatusCode + ")");
            await Console.Out.WriteLineAsync("\nResult:\n" + todos.Result);
        }
    }

    
}