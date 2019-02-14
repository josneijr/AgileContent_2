using System;
using System.Collections.Generic;
using AgileContent2.Entities;

namespace AgileContent2.Interfaces
{
    public interface IDataInterpreter
    {
        List<DataEvent> InterpretData(string data);
    }
}
