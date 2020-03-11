using Microsoft.Practices.Unity.Configuration.Tests.TestObjects.MyGenericTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Unity;
using Unity.Injection;

namespace Microsoft.Practices
{
    [TestClass]
    public class GenericAndNonGenericTypes : MicrosoftPracticesFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "Generics.config");

        [TestMethod]
        public void CanResolveConfiguredGenericType()
        {
            LoadContainer("container1");
            var result = Container.Resolve<ItemsCollection<IItem>>();

            Assert.AreEqual(8, result.Items.Length);
            Assert.IsInstanceOfType(result.Printer, typeof(MyPrintService<IItem>));
        }

        [TestMethod]
        public void CanResolveConfiguredGenericTypeWithSpecificElements()
        {
            LoadContainer("container1");
            var result = Container.Resolve<ItemsCollection<IItem>>("OnlyThree");
            Assert.AreEqual(3, result.Items.Length);
        }

        [TestMethod]
        public void CanConfigureGenericArrayInjectionViaAPI()
        {
            LoadContainer("container1");
            Container.RegisterType(typeof(ItemsCollection<>), "More",
                new InjectionConstructor("MyGenericCollection", new ResolvedParameter(typeof(IGenericService<>))),
                new InjectionProperty("Items",
                    new GenericResolvedArrayParameter("T",
                        new GenericParameter("T", "Xray"),
                        new GenericParameter("T", "Common"),
                        new GenericParameter("T", "Tractor"))));

            var result = Container.Resolve<ItemsCollection<IItem>>("More");
            Assert.AreEqual(3, result.Items.Length);
        }

        [TestMethod]
        public void CanResolveConfiguredResolvableOptionalGenericType()
        {
            LoadContainer("container1");
            var result = Container.Resolve<ItemsCollection<IItem>>("optional resolvable");

            Assert.AreEqual(1, result.Items.Length);
            Assert.IsNotNull(result.Items[0]);
            Assert.AreEqual("Charlie Miniature", result.Items[0].ItemName);
        }

        [TestMethod]
        public void CanResolveConfiguredNonResolvableOptionalGenericType()
        {
            LoadContainer("container1");
            var result = Container.Resolve<ItemsCollection<IItem>>("optional non resolvable");

            Assert.AreEqual(1, result.Items.Length);
            Assert.IsNull(result.Items[0]);
        }

        [TestMethod]
        public void CanResolveConfiguredGenericTypeWithArrayInjectedInConstructor()
        {
            LoadContainer("container1");
            var result = Container.Resolve<ItemsCollection<IItem>>("ThroughConstructor");

            Assert.AreEqual(8, result.Items.Length);
            Assert.IsInstanceOfType(result.Printer, typeof(MyPrintService<IItem>));
        }

        [TestMethod]
        public void CanResolveConfiguredGenericTypeWithArrayInjectedInConstructorWithSpecificElements()
        {
            LoadContainer("container1");
            var result = Container.Resolve<ItemsCollection<IItem>>("ThroughConstructorWithSpecificElements");

            Assert.AreEqual(3, result.Items.Length);
        }

        [TestMethod]
        public void CanResolveConfiguredGenericTypeWithArrayOfArraysInjectedInConstructorWithSpecificElements()
        {
            LoadContainer("container1");
            var result = Container.Resolve<ItemsCollection<IItem>>("ArrayOfArraysThroughConstructorWithSpecificElements");

            Assert.AreEqual(3, result.Items.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DependencyElementForGenericPropertyArrayWithTypeSet()
        {
            LoadContainer("dependency with type");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ParameterWithValueElement()
        {
            LoadContainer("property with value");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenericArrayPropertyWithValueElement()
        {
            LoadContainer("generic array property with value");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ChainedGenericParameterWithValueElement()
        {
            LoadContainer("chained generic parameter with value");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DependencyElementForArrayWithTypeSet()
        {
            LoadContainer("generic array property with dependency with type");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ArrayElementForChainedGenericParameter()
        {
            LoadContainer("chained generic parameter with array");
            Assert.Fail();
        }
    }
}
