using News.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataSql
{
    public class SaveLocalChanges
    {
        public static void SaveInData()
        {
            try
            {
                DataLayer.Data.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public static void ClearData() 
        {
          List<Article> articles = DataLayer.Data.Articles.ToList();

            foreach (Article article in articles) 
            {
                DataLayer.Data.Articles.Remove(article);
            }
        }
    }
}
