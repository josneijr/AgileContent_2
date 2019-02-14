using AgileContent2.Domains.DataWriters;
using AgileContent2.Entities;
using AgileContent2.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AgileContent_Test
{
    [TestFixture()]
    public class TestAgora
    {
        List<DataEvent> example = new List<DataEvent> {
            new DataEvent(1, 12, "/teste", "http 1.1", "teste_system", HttpReturnCode.OK, OperationResult.HIT, HttpOperationType.GET)
        };

        IDataReformat dataReformat = new Agora();

        [Test()]
        public void Test_AgoraHeader()
        {
            string output = dataReformat.ReformatData(new List<DataEvent>());

            string expected = "#Version: 1.0\n" +
                              "#Date: 15/12/2017 23:01:06\n" +
                              "#Fields: provider http-method status-code uri-path time-taken response - size cache - status\n\n";

            Assert.AreEqual(output, expected);
        }

        [Test()]
        public void Test_AgoraContent()
        {
            string output = dataReformat.ReformatData(example);

            string expected = "#Version: 1.0\n" +
                              "#Date: 15/12/2017 23:01:06\n" +
                              "#Fields: provider http-method status-code uri-path time-taken response - size cache - status\n\n" +
                              "\"teste_system\" GET 200 /teste 12 1 HIT\n";

            Assert.AreEqual(output, expected);
        }
    }
}
