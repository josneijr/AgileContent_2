using System;
using System.Collections.Generic;
using AgileContent2.Entities;
using AgileContent2.Interfaces;

namespace AgileContent2.Domains.DataWriters
{
    public class Agora : IDataReformat
    {
        private string Header()
        {
            return "# Version: 1.0\n" +
                   "# Date: 15/12/2017 23:01:06\n" +
                   "# Fields: provider http-method status-code uri-path time-taken response - size cache - status\n\n";
        }

        public string ReformatData(List<DataEvent> events)
        {
            string result = Header();

            foreach(var dataEvent in events)
            {
                result += "\"" + dataEvent.systemName + "\" ";
                result += dataEvent.httpOperationType.ToString() + " ";
                result += ((int)dataEvent.httpReturnCode).ToString() + " ";
                result += dataEvent.httpPath + " ";
                result += Math.Round(dataEvent.operationTime).ToString() + " ";
                result += dataEvent.responseSize.ToString() + " ";
                result += GetOperationResult(dataEvent.operationResult);
                result += "\n";
            }

            return result;
        }

        string GetOperationResult(OperationResult value)
        {
            switch(value)
            {
                case OperationResult.HIT:
                    return "HIT";
                case OperationResult.INVALIDATE:
                    return "REFRESH_HIT";
                case OperationResult.MISS:
                    return "MISS";
                default:
                    return "";
            }
        }
    }
}
