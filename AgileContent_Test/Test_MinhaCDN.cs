using AgileContent2.Domains.DataInterpreters;
using AgileContent2.Entities;
using AgileContent2.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgileContent_Test
{
    [TestFixture()]
    public class Test_MinhaCDN
    {
        IDataInterpreter dataInterpreter = new MinhaCDN();

        string example = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2\n" +
                         "101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4\n" +
                         "199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9\n" +
                         "312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1";

        [Test()]
        public void Test_NumberEvents()
        {
            List<DataEvent> result = dataInterpreter.InterpretData(example);

            // Testar
            Assert.AreEqual(result.Count, 4);
        }

        [Test()]
        public void Test_NumberGET()
        {
            List<DataEvent> result = dataInterpreter.InterpretData(example);
            List<DataEvent> resultFiltered = result.Where(t => t.httpOperationType == HttpOperationType.GET).ToList();

            Assert.AreEqual(resultFiltered.Count, 3);
        }

        [Test()]
        public void Test_NumberPOST()
        {
            List<DataEvent> result = dataInterpreter.InterpretData(example);
            List<DataEvent> resultFiltered = result.Where(t => t.httpOperationType == HttpOperationType.POST).ToList();

            Assert.AreEqual(resultFiltered.Count, 1);
        }
    }
}
