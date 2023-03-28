using Microsoft.AspNetCore.Mvc;
using News.Entities;
using News.Model;
using News.DataSql;

namespace News.Server.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class GetArticles
    {
        [HttpGet("GetArticlesFromRSS")]
        public  void GetAllArticlesList()
        {

            try
            {
                
               
                  Task.Run(async () =>
                  {
                    while (true)
                    {
                        List<RssSubjectsUrl> rssSubjectsUrls = DataLayer.Data.RssUrls.ToList();
                        foreach (RssSubjectsUrl RssUrl in rssSubjectsUrls)
                        {
                            await MainManager.Instance.requestGet.XMLRequestGet(RssUrl.Link);
                        }
                        MainManager.InitSave();


                         Thread.Sleep(1000*60*60);

                        MainManager.InitClear();

                     
                      }

                });
               
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }



            
        }
        [HttpPost("getArticlesForUser")]
        public void SetUserSubjects(string userEmail)
        {
            List<UserSubject> userSubjectsList = MainManager.Instance.GetDataFromDB("");
           List<Article> articlesList=(List<Article>)MainManager.Instance.articleManager.GetDataFromDB("article");

            foreach (Article article in articlesList) 
            {

            }
            
        }

    }
}
