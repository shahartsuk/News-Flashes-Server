using News.DataSql;
using News.Model;
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
           
                List<Article> ArticlesList = new List<Article>();
                AddArticles addArticles= new AddArticles();
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

                            
                            if (articleCounter < 10)
                            {
                               ArticleProvider article = new ArticleProvider(urlLink);
                               article.myArticle.Title = node["title"].InnerText;
                                article.myArticle.WebLink = node["link"].InnerText;
                                article.myArticle.LinkImage = article.myArticle.ExtractImageFromItem(node);
                                article.myArticle.Description = article.myArticle.ExtractClearDescriptionFromItem(node);
                                article.myArticle.subjectName = DataLayer.Data.Subjects.ToList().Find(s => s.RssSubjects.ToList().Find(r => r.Link == urlLink) != null).Name;
                                articleCounter++;
                                ArticlesList.Add(article.myArticle);
                            }
                        }
                    addArticles.AddArticleToDB(ArticlesList);

                   

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
