using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Loading
{
    [TestClass]
    public class Sections : Unity.Specification.Configuration.Sections.SpecificationTests
    {
        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceCompillation());
        }
    }
}
