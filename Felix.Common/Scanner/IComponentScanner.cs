using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Felix.Common.Scanner
{
    public interface IComponentScanner
    {
        IScanResult Scan();
    }
}
