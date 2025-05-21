using System;

namespace LSL.ExecuteIf;

internal static class GuardObjectExtensions
{
    public static T AssertNotNull<T>(this T source, string parameterName)
    {
        if (source is null) throw new ArgumentNullException(parameterName);

        return source;
    }
}