using System;

namespace AgileContent2.Entities
{
    public enum HttpReturnCode
    {
        OK = 200,
        NOT_FOUND = 404
    }

    public enum HttpOperationType
    {
        GET,
        POST
    }

    public enum OperationResult
    {
        HIT,
        MISS,
        INVALIDATE
    }

    public class DataEvent
    {
        public int responseSize { get; set; }
        public int operationTime { get; set; }
        public string httpPath { get; set; }
        public string httpVersion { get; set; }
        public string systemName { get; set; }
        public HttpReturnCode httpReturnCode { get; set; }
        public OperationResult operationResult { get; set; }
        public HttpOperationType httpOperationType { get; set; }

        public DataEvent(int _responseSize, int _operationTime, string _httpPath, 
                    string _httpVersion, string _systemName, HttpReturnCode _httpReturnCode,
                    OperationResult _operationResult, HttpOperationType _httpOperationType)
        {
            responseSize = _responseSize;
            operationTime = _operationTime;
            httpPath = _httpPath;
            httpVersion = _httpVersion;
            systemName = _systemName;
            httpReturnCode = _httpReturnCode;
            httpOperationType = _httpOperationType;
            operationResult = _operationResult;
        }
    }
}
