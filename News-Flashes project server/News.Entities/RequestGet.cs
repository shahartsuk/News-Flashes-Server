using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace News.Entities
{
    public class RequestGet
    {
        public async Task XMLRequestGet()
        {
            using (var client = new HttpClient())
            {
                // Make a GET request to the URL 
                var response = await client.GetAsync("https://rss.walla.co.il/feed/22");

                // Ensure the response was successful 
                response.EnsureSuccessStatusCode();

                // Read the content of the response 
                var content = await response.Content.ReadAsStringAsync();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(content);

                foreach (XmlNode node in xmlDoc.SelectNodes("//item"))
                {
                    //string title = node.SelectNodes("title")[0].InnerText;
                    MainManager.Instance.Walla.Title = node["title"].InnerText;
                    MainManager.Instance.Walla.WebLink = node["link"].InnerText;
                    string description = node["description"].InnerText;
                    string[] separator = { "src=", "<br/>", "</p>", " /></a>" };
					string[] strArr = description.Split(separator, StringSplitOptions.RemoveEmptyEntries);
					MainManager.Instance.Walla.Description = strArr[2];
                    MainManager.Instance.Walla.LinkImage = strArr[1];
                }

                // Output the content of the response 
                Console.WriteLine(content);
            }
        }
    }
}
