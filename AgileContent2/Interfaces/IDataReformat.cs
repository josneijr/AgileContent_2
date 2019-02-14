using System;
using System.Collections.Generic;
using AgileContent2.Entities;

namespace AgileContent2.Interfaces
{
    public interface IDataReformat
    {
        string ReformatData(List<DataEvent> events);
    }
}
