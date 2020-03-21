using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Unity.Configuration.Collections
{
    public class RegistrationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            throw new NotImplementedException();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            throw new NotImplementedException();
        }
    }
}
