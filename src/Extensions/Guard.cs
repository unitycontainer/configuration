using System;
using System.Globalization;
using System.Reflection;

namespace Microsoft.Practices.Unity.Utility
{
    /// <summary>
    /// A static helper class that includes various parameter checking routines.
    /// </summary>
    internal static partial class Guard
    {
        /// <summary>
        /// Verifies that an argument type is assignable from the provided type (meaning
        /// interfaces are implemented, or classes exist in the base class hierarchy).
        /// </summary>
        /// <param name="assignmentTargetType">The argument type that will be assigned to.</param>
        /// <param name="assignmentValueType">The type of the value being assigned.</param>
        /// <param name="argumentName">Argument name.</param>
        public static void TypeIsAssignable(Type assignmentTargetType, Type assignmentValueType, string argumentName)
        {
            if (assignmentTargetType == null)
            {
                throw new ArgumentNullException("assignmentTargetType");
            }

            if (assignmentValueType == null)
            {
                throw new ArgumentNullException("assignmentValueType");
            }

            if (!assignmentTargetType.GetTypeInfo().IsAssignableFrom(assignmentValueType.GetTypeInfo()))
            {
                throw new ArgumentException(string.Format(
                    CultureInfo.CurrentCulture,
                    "The type {1} cannot be assigned to variables of type {0}.",
                    assignmentTargetType,
                    assignmentValueType),
                    argumentName);
            }
        }

        /// <summary>
        /// Verifies that an argument instance is assignable from the provided type (meaning
        /// interfaces are implemented, or classes exist in the base class hierarchy, or instance can be 
        /// assigned through a runtime wrapper, as is the case for COM Objects).
        /// </summary>
        /// <param name="assignmentTargetType">The argument type that will be assigned to.</param>
        /// <param name="assignmentInstance">The instance that will be assigned.</param>
        /// <param name="argumentName">Argument name.</param>
        public static void InstanceIsAssignable(Type assignmentTargetType, object assignmentInstance, string argumentName)
        {
            if (assignmentTargetType == null)
            {
                throw new ArgumentNullException("assignmentTargetType");
            }

            if (assignmentInstance == null)
            {
                throw new ArgumentNullException("assignmentInstance");
            }

            if (!assignmentTargetType.GetTypeInfo().IsAssignableFrom(assignmentInstance.GetType().GetTypeInfo()))
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        "The type {1} cannot be assigned to variables of type {0}.",
                        assignmentTargetType,
                        GetTypeName(assignmentInstance)),
                    argumentName);
            }
        }

        private static string GetTypeName(object assignmentInstance)
        {
            string assignmentInstanceType;
            try
            {
                assignmentInstanceType = assignmentInstance.GetType().FullName;
            }
            catch (Exception)
            {
                assignmentInstanceType = "<unknown>";
            }
            return assignmentInstanceType;
        }
    }
}
