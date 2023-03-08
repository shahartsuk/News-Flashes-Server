using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;

namespace News.Entities
{
    public class RequestPost
    {
        public async Task XMLRequestPost()
        {
            using (var client = new HttpClient())
            {
                // Create a JSON payload to be sent with the request 
                var payload = new { username = "example_username", password = "example_password" };

                // Make a POST request to the URL 
                var response = await client.PostAsJsonAsync("https://www.example.com/api/login", payload);

                // Ensure the response was successful 
                response.EnsureSuccessStatusCode();

                // Read the content of the response 
                var content = await response.Content.ReadAsStringAsync();

                // Output the content of the response 
                Console.WriteLine(content);
            }
        }
    }
}
