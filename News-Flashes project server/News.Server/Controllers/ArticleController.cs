﻿using Microsoft.AspNetCore.Mvc;
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
                // Task Getxml;
                //RequestGet requestGet = new RequestGet();

               
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
        [HttpPost("GetArticlesFromDB")]
        public void SetUserSubjects(string[] userSubjects)
        {
            
        }

    }
}
