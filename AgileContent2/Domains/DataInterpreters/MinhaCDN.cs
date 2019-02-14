using System;
using System.Collections.Generic;
using AgileContent2.Entities;
using AgileContent2.Interfaces;
using System.Linq;

namespace AgileContent2.Domains.DataInterpreters
{
    public class MinhaCDN : IDataInterpreter
    {
        public MinhaCDN()
        {
        }

        public List<DataEvent> InterpretData(string data)
        {
            List<DataEvent> dataFound = new List<DataEvent>();

            List<string[]> lines = data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                                        .Select(t => t.Split(new char[] { '|', '"', ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToList();

            foreach(var line in lines)
            {
                int responseSize = 0;
                int responseTime = 0;

                if (line.Length < 7) continue;

                if (Int32.TryParse(line[0], out responseSize)) continue;

                if (Int32.TryParse(line[6], out responseTime)) continue;

                DataEvent dataEvent = new DataEvent(
                    responseSize,
                    responseTime,
                    line[4],
                    line[5], 
                    "MINHA CDN",
                    ConvertReturnCode(line[1]),
                    ConvertOperationResult(line[2]),
                    ConvertOperationType(line[3])
                );

                dataFound.Add(dataEvent);
            }

            return dataFound;
        }

        HttpReturnCode ConvertReturnCode(string value)
        {
            return HttpReturnCode.OK;
        }

        OperationResult ConvertOperationResult(string value)
        {
            return OperationResult.HIT;
        }

        HttpOperationType ConvertOperationType(string value)
        {
            return HttpOperationType.GET;
        }
    }
}
