using Microsoft.Practices.Unity.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml;

namespace WorkInProgress.Tests
{
    [TestClass]
    public class When_DeserializingParameterElement
    {
        [TestMethod]
        public void Then_CanDeserializeSingleInjectionValueChild()
        {
            var elementXml = @"
                <param name=""connectionString"">
                    <value value=""northwind"" />
                </param>";

            var reader = new XmlTextReader(new StringReader(elementXml));
            var result = reader.MoveToContent();
            var element = new ParameterElement();

            element.Deserialize(reader);

            Assert.AreSame(typeof(ValueElement), element.Value.GetType());
            Assert.AreEqual("northwind", ((ValueElement)element.Value).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Configuration.ConfigurationErrorsException))]
        public void Then_DeserializingMultipleInjectionValueChildrenThrows()
        {
            var elementXml = @"
                <param name=""connectionString"">
                    <value value=""northwind"" />
                    <value value=""northwind"" />
                </param>";

            var reader = new XmlTextReader(new StringReader(elementXml));
            var result = reader.MoveToContent();
            var element = new ParameterElement();

            element.Deserialize(reader);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Configuration.ConfigurationErrorsException))]
        public void Then_DeserializingWithParametersAndValueChildrenThrows()
        {
            var elementXml = @"
                <param name=""connectionString"" value=""northwind2"">
                    <value value=""northwind"" />
                </param>";

            var reader = new XmlTextReader(new StringReader(elementXml));
            var result = reader.MoveToContent();
            var element = new ParameterElement();

            element.Deserialize(reader);
        }
    }

    [TestClass]
    public class When_DeserializingPropertyElement
    {
        [TestMethod]
        public void Then_CanDeserializeSingleInjectionValueChild()
        {
            var elementXml = @"
                <property name=""connectionString"">
                    <value value=""northwind"" />
                </property>";

            var reader = new XmlTextReader(new StringReader(elementXml));
            var result = reader.MoveToContent();
            var element = new PropertyElement();

            element.Deserialize(reader);

            Assert.AreSame(typeof(ValueElement), element.Value.GetType());
            Assert.AreEqual("northwind", ((ValueElement)element.Value).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Configuration.ConfigurationErrorsException))]
        public void Then_DeserializingMultipleInjectionValueChildrenThrows()
        {
            var elementXml = @"
                <property name=""connectionString"">
                    <value value=""northwind"" />
                    <value value=""northwind"" />
                </property>";

            var reader = new XmlTextReader(new StringReader(elementXml));
            var result = reader.MoveToContent();
            var element = new PropertyElement();
            element.Deserialize(reader);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Configuration.ConfigurationErrorsException))]
        public void Then_DeserializingWithParametersAndValueChildrenThrows()
        {
            var elementXml = @"
                <property name=""connectionString"" value=""northwind2"">
                    <value value=""northwind"" />
                </property>";

            var reader = new XmlTextReader(new StringReader(elementXml));
            var result = reader.MoveToContent();
            var element = new PropertyElement();
            element.Deserialize(reader);
        }
    }
}
