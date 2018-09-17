using System;
using System.Collections.Generic;
using System.Text;

namespace Fructika
{
    public interface IAppVersionProvider
    {
        string Version { get; }
    }
}
