using System;
using System.Collections.Generic;
using AgileContent2.Entities;
using AgileContent2.Interfaces;
using System.Linq;

namespace AgileContent2.Domains.DataInterpreters
{
    public class MinhaCDN : IDataInterpreter
    {
        public List<DataEvent> InterpretData(string data)
        {
            List<DataEvent> dataFound = new List<DataEvent>();

            List<string[]> lines = data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                                        .Select(t => t.Split(new char[] { '|', '"', ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToList();

            foreach(var line in lines)
            {
                int responseSize = 0;
                double responseTime = 0;

                if (line.Length < 7) continue;

                if (!Int32.TryParse(line[0], out responseSize)) continue;

                if (!Double.TryParse(line[6], out responseTime)) continue;

                try
                {
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
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

            }

            return dataFound;
        }

        HttpReturnCode ConvertReturnCode(string value)
        {
            switch(value)
            {
                case "200":
                    return HttpReturnCode.OK;
                case "404":
                    return HttpReturnCode.NOT_FOUND;
                default:
                    throw new Exception("Invalid HttpReturnCode, value " + value);
            }
        }

        OperationResult ConvertOperationResult(string value)
        {
            switch (value)
            {
                case "HIT":
                    return OperationResult.HIT;
                case "MISS":
                    return OperationResult.MISS;
                case "INVALIDATE":
                    return OperationResult.INVALIDATE;
                default:
                    throw new Exception("Invalid OperationResult, value " + value);
            }
        }

        HttpOperationType ConvertOperationType(string value)
        {
            switch (value)
            {
                case "GET":
                    return HttpOperationType.GET;
                case "POST":
                    return HttpOperationType.POST;
                default:
                    throw new Exception("Invalid HttpOperationType, value " + value);
            }
        }
    }
}
