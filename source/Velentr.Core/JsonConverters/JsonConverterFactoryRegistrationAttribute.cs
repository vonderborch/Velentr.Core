namespace Velentr.Core.JsonConverters;

/// <summary>
///     Marks a class as a JSON converter factory that should be registered for type conversion support.
///     This attribute is applied to types that implement the JsonConverterFactory interface,
///     indicating that they provide custom logic for serializing and deserializing specific types.
/// </summary>
public class JsonConverterFactoryRegistrationAttribute : Attribute
{
}
