using News.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataSql
{
    public class SubjectDB
    {
        public static List<Subject> GetSubjectsDB()
        {
            return DataLayer.Data.Subjects.ToList();
        }
    }
}
