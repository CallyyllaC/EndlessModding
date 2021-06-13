using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2.Common.Interfaces
{
    interface ES2XMLClass
    {
        object Get();
        string RawXMLInner { get; }
        string RawXMLOuter { get; }
        bool Custom { get; set; }
    }
}
