namespace Unity.Configuration
{
    internal class Constants
    {
        public static string CannotCreateContainerConfiguringElement = "An abstract ContainerConfiguringElement cannot be created.Please specify a concrete type.";
        public static string CannotCreateExtensionConfigurationElement = "An abstract ExtensionConfigurationElement object cannot be created.Please specify a concrete type.";
        public static string CannotCreateInjectionMemberElement = "An abstract InjectionMemberElement object cannot be created.Please specify a concrete type.";
        public static string CannotCreateParameterValueElement = "An abstract ParameterInjectionParameterValueElement object cannot be created.Please specify a concrete type.";
        public static string CouldNotResolveType = "The type name or alias {0} could not be resolved.Please check your configuration file and verify this type name.";
        public static string DependencyForGenericParameterWithTypeSet = "The dependency element for generic parameter {0} must not have an explicit type name but has '{1}'.";
        public static string DependencyForOptionalGenericParameterWithTypeSet = "The optional dependency element for generic parameter {0} must not have an explicit type name but has '{1}'.";
        public static string DestinationNameFormat = "{0} {1}";
        public static string DuplicateParameterValueElement = "The injection configuration for {0} has multiple values.";
        public static string ElementTypeNotRegistered = "The configuration element type {0} has not been registered with the section.";
        public static string ElementWithAttributesAndParameterValueElements = "The injection configuration for {0} is specified through both attributes and child value elements.";
        public static string ExtensionTypeNotFound = "Could not load section extension type {0}.";
        public static string ExtensionTypeNotValid = "The extension type {0} does not derive from SectionExtension.";
        public static string InvalidExtensionElementType = "The extension element type {0} that is being added does not derive from ContainerConfiguringElement, InjectionMemberElement, or ParameterInjectionParameterValueElement.An extension element must derive from one of these types.";
        public static string InvalidValueAttributes = "No valid attributes were found to construct the value for the { 0}. Please check the configuration file.";
        public static string NoMatchingConstructor = "Configuration is incorrect, the type {0} does not have a constructor that takes parameters named {1}.";
        public static string NoMatchingMethod = "Configuration is incorrect, the type {0} does not have a method named {1} that takes parameters named {2}.";
        public static string NoSuchContainer= "The container named '{0}' is not defined in this configuration section.";
        public static string NoSuchProperty = "The type {0} does not have a property named {1}.";
        public static string NotAnArray = "The configuration is set to inject an array, but the type {0} is not an array type.";
        public static string Parameter = "parameter";
        public static string Property = "property";
        public static string RequiredPropertyMissing =  "The attribute {0} must be present and non-empty.";
        public static string ValueNotAllowedForGenericArrayType = "The value element for {1} was specified for the generic array type {0}. InjectionParameterValue elements are not allowed for generic array types.";
        public static string ValueNotAllowedForGenericParameterType = "The value element for {1} was specified for the generic parameter type {0}. InjectionParameterValue elements are not allowed for generic parameter types.";
        public static string ValueNotAllowedForOpenGenericType = "The value element for {1} was specified for the generic type {0}. InjectionParameterValue elements are not allowed for generic types.";
    }

}




