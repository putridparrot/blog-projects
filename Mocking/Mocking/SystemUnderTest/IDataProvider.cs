using System;
using System.Collections.Generic;

namespace Mocking.SystemUnderTest
{
    public interface IDataProvider
    {
        IList<string> GetIds(string filter);
        event EventHandler Updates;
    }
}
