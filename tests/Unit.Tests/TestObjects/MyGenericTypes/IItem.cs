

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Practices.Unity.Configuration.Tests.TestObjects.MyGenericTypes
{
    public interface IItem
    {
        string ItemName { get; set; }
        string ItemType { get; }
        ItemCategory Category { get; }
    }
}
