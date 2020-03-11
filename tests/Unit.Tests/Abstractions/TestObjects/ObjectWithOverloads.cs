

namespace Microsoft.Practices.Unity.Configuration.Tests.TestObjects
{
    internal class ObjectWithOverloads
    {
        public int FirstOverloadCalls;
        public int SecondOverloadCalls;

        public void CallMe(int param)
        {
            ++FirstOverloadCalls;
        }

        public void CallMe(string param)
        {
            ++SecondOverloadCalls;
        }
    }
}
