using System;
using System.Text;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration.Tests.ConfigFiles;
using Microsoft.Practices.Unity.TestSupport.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;


namespace Microsoft.Practices.Unity.Configuration.Tests
{
    /// <summary>
    /// support difference type for optional #130
    /// </summary>
    [TestClass]
    public class OptionalWithTypeFixture : ContainerConfiguringFixture<ConfigFileLocator>
    {
        public OptionalWithTypeFixture()
           : base("OptionalWithType", String.Empty)
        {
        }

        [TestMethod]
        public void When_ConfigurationOptionalWithTypeByPropertyInjection()
        {
            var circle = Container.Resolve<Circle>("Circle");
            var square = Container.Resolve<Square>("Square");
            var myPicture = Container.Resolve<MyPicture>("PropertyInjection");
            Assert.IsTrue(circle == myPicture.MyCircle, "MyCircle is Circle");
            Assert.IsTrue(square == myPicture.MySquare, "MySquare is Square");
        }
        [TestMethod]
        public void When_ConfigurationOptionalWithTypeByArrayInjection()
        {
            var circle = Container.Resolve<Circle>("Circle");
            var square = Container.Resolve<Square>("Square");
            var myPicture = Container.Resolve<MyPicture>("ArrayInjection");
            var items = myPicture.Items;
            Assert.IsTrue(items != null && items.Length == 2, "Two Items");
            Assert.IsTrue(items[0] == circle, "First is Circle");
            Assert.IsTrue(items[1] == square, "Second is Square");
        }
        [TestMethod]
        public void When_ConfigurationOptionalWithTypeByMethodInjection()
        {
            var circle = Container.Resolve<Circle>("Circle");
            var square = Container.Resolve<Square>("Square");
            var myPicture = Container.Resolve<MyPicture>("MethodInjection");
            Assert.IsTrue(circle == myPicture.MyCircle, "MyCircle is Circle");
            Assert.IsTrue(square == myPicture.MySquare, "MySquare is Square");
        }
        [TestMethod]
        public void When_ConfigurationOptionalWithTypeByConstructorInjection()
        {
            var circle = Container.Resolve<Circle>("Circle");
            var square = Container.Resolve<Square>("Square");
            var myPicture = Container.Resolve<MyPicture>("ConstructorInjection");
            Assert.IsTrue(circle == myPicture.MyCircle, "MyCircle is Circle");
            Assert.IsTrue(square == myPicture.MySquare, "MySquare is Square");
        }

        #region TestSupport
        /// <summary>
        /// 
        /// </summary>
        public abstract class Shape
        {
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }
            public override string ToString()
            {
                return $"A circle with a radius of {Radius}";
            }
        }
        public class Square : Shape
        {
            public double Side { get; set; }
            public override string ToString()
            {
                return $"Square with side of {Side}";
            }
        }

        public class MyPicture : Shape
        {
            public MyPicture() { }

            public MyPicture(Shape myCircle, Shape mySquare)
            {
                MyCircle = myCircle;
                MySquare = mySquare;
            }
            public Shape MyCircle { get; set; }
            public Shape MySquare { get; set; }

            public Shape[] Items { get; set; }

            public void Initialize(Shape myCircle, Shape mySquare)
            {
                MyCircle = myCircle;
                MySquare = mySquare;
            }
            public override string ToString()
            {
                var builder = new StringBuilder();
                builder.Append($"MyPicture with {MyCircle.ToString()} and {MySquare.ToString()}");

                return $"MyPicture has {MyCircle.ToString()} and { MySquare.ToString()}.";
            }
        }
        #endregion
    }
}
