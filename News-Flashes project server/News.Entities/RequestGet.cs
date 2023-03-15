using News.DataSql;
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
    public class RequestGet: BaseEntity
    {
        public RequestGet() 
        {

        }
        public async Task XMLRequestGet(string urlLink)
        {
            int articleCounter = 0;

            try
            {
                AddArticle addArticle = new AddArticle();
                
            using (var client = new HttpClient())
            {
                // Make a GET request to the URL 
                var response = await client.GetAsync(urlLink);

                // Ensure the response was successful 
                response.EnsureSuccessStatusCode();

                // Read the content of the response 
                var content = await response.Content.ReadAsStringAsync();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(content);

                foreach (XmlNode node in xmlDoc.SelectNodes("//item"))
                {
                        
                     //string title = node.SelectNodes("title")[0].InnerText;
                    string description = node["description"].InnerText;
                    string[] separator = { "src=", "<br/>", "</p>", " /></a>" };
					string[] strArr = description.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if(strArr.Length > 2 && articleCounter <= 10)
                        {
                            ArticleProvider article = new ArticleProvider(urlLink);
                            article.myArticle.Title = node["title"].InnerText;
                            article.myArticle.WebLink = node["link"].InnerText;
                            article.myArticle.Description = strArr[2];
                            article.myArticle.LinkImage = strArr[1];

                            article.myArticle.subject = DataLayer.Data.Subjects.ToList().Find(s => s.RssSubjects.ToList().Find(r => r.Link == urlLink) != null);

                            articleCounter++;
                            addArticle.AddArticleToDB(article.myArticle);
                        }
                }
                    addArticle.SaveArticleList();
                }
            }
            catch (Exception ex)
            {
                MainManager.Instance.logger.myLog.LogException("Local error Entities.RequestGet", ex);
                return;
            }
        }
    }
}
