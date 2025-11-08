using System;

namespace LSL.ExecuteIf;

/// <summary>
/// Object extensions
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Conditionally execute a delegate and return the source object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <param name="actionToExecute"></param>
    /// <param name="elseActionToExecute"></param>
    /// <returns></returns>
    public static T ExecuteIf<T>(this T source, Func<bool> predicate, Action<T> actionToExecute, Action<T>? elseActionToExecute = null) =>
        source.ExecuteIf(predicate.AssertNotNull(nameof(predicate))(), actionToExecute, elseActionToExecute);

    /// <summary>
    /// Conditionally execute a delegate and return the source object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="condition"></param>
    /// <param name="actionToExecute"></param>
    /// <param name="elseActionToExecute"></param>
    /// <returns></returns>
    public static T ExecuteIf<T>(this T source, bool condition, Action<T> actionToExecute, Action<T>? elseActionToExecute = null)
    {
        if (condition)
        {
            actionToExecute.AssertNotNull(nameof(actionToExecute))(source);
        }
        else
        {
            elseActionToExecute?.Invoke(source);
        }

        return source;
    }
}
