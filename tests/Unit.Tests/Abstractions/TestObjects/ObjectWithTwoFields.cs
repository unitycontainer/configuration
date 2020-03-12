using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Microsoft.Practices.Unity.TestSupport
{
    public class ObjectWithTwoFields
    {
        [Dependency]
        public object Obj1;

        [Dependency]
        public object Obj2;

        public object Prop1 { get; set; }

        public void Validate()
        {
            Assert.IsNotNull(Obj1);
            Assert.IsNotNull(Obj2);
            Assert.AreNotSame(Obj1, Obj2);
        }
    }
}
