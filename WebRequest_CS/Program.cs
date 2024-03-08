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
        #region GET method
        await Console.Out.WriteLineAsync("GET request: ");
        Answer todos = await Get.Request("http://localhost:3000/todo", new Dictionary<string, string>() { { "User-Agent", "MyTestApplication/1.0.0" } });
        await Console.Out.WriteLineAsync(todos.InternalError ? todos.InternalErrorMessage : "No internal errors!");
        if (!todos.InternalError) 
        { 
            await Console.Out.WriteLineAsync("\nServer sent headers:\n" + todos.Response?.Headers.ToString());
            await Console.Out.WriteLineAsync("\nStatusCode: " + todos.Response?.StatusCode + " (" + (int)todos.Response?.StatusCode + ")");
            await Console.Out.WriteLineAsync("\nResult:\n" + todos.Result);
        }
        #endregion

        await Console.Out.WriteLineAsync("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();

        #region POST method
        Todo task = new Todo("Test task", "Created task from application", false);
        await Console.Out.WriteLineAsync("POST request: ");
        Answer createTask = await Post.Request("http://localhost:3000/todo", new Dictionary<string, string>() { { "User-Agent", "MyTestApplication/1.0.0" } }, task);
        await Console.Out.WriteLineAsync(createTask.InternalError ? createTask.InternalErrorMessage : "No internal errors!");
        if (!createTask.InternalError)
        {
            await Console.Out.WriteLineAsync("\nServer sent headers:\n" + createTask.Response?.Headers.ToString());
            await Console.Out.WriteLineAsync("\nStatusCode: " + createTask.Response?.StatusCode + " (" + (int)createTask.Response?.StatusCode + ")");
            await Console.Out.WriteLineAsync("\nResult:\n" + createTask.Result);
        }
        #endregion

        await Console.Out.WriteLineAsync("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();

        await Console.Out.WriteAsync("Please enter the number of the task you want to delete: ");
        uint dId = uint.Parse(Console.ReadLine());

        #region DELETE method
        await Console.Out.WriteLineAsync("DELETE request: ");
        Answer deleteTask = await Delete.Request("http://localhost:3000/todo/" + dId, new Dictionary<string, string>() { { "User-Agent", "MyTestApplication/1.0.0" } });
        await Console.Out.WriteLineAsync(deleteTask.InternalError ? deleteTask.InternalErrorMessage : "No internal errors!");
        if (!deleteTask.InternalError)
        {
            await Console.Out.WriteLineAsync("\nServer sent headers:\n" + deleteTask.Response?.Headers.ToString());
            await Console.Out.WriteLineAsync("\nStatusCode: " + deleteTask.Response?.StatusCode + " (" + (int)deleteTask.Response?.StatusCode + ")");
            await Console.Out.WriteLineAsync("\nResult:\n" + deleteTask.Result);
        }

        #endregion
    }


}