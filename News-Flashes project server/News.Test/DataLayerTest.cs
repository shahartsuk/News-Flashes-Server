using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Entities;

namespace News.Test
{
    [TestFixture]
    public class DataLayerTest
    {
        [Test,Category("DataBase"),Order(1)]
        public void DBTesting()
        {
            DataLayer data;
            Assert.DoesNotThrow(() => { data = DataLayer.Data; });
        }
    }
}
