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
    /// <param name="source">The source object</param>
    /// <param name="predicate">The predicate to evaluate</param>
    /// <param name="actionToExecute">The action to run if <paramref name="predicate"/> returns <see langword="true" /></param>
    /// <param name="elseActionToExecute">The action to run if <paramref name="predicate"/> returns <see langword="false" />. Can be omitted</param>
    /// <returns></returns>
    public static T ExecuteIf<T>(this T source, Func<bool> predicate, Action<T> actionToExecute, Action<T>? elseActionToExecute = null) =>
        source.ExecuteIf(predicate.AssertNotNull(nameof(predicate))(), actionToExecute, elseActionToExecute);

    /// <summary>
    /// Conditionally execute a delegate and return the source object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">The source object</param>
    /// <param name="condition">The condition</param>
    /// <param name="actionToExecute">The action to run if <paramref name="condition"/> is <see langword="true" /></param>
    /// <param name="elseActionToExecute">The action to run if <paramref name="condition"/> is <see langword="false" />. Can be omitted</param>
    /// <returns></returns>
    public static T ExecuteIf<T>(this T source, bool condition, Action<T> actionToExecute, Action<T>? elseActionToExecute = null) =>
        condition
            ? source.ConfigureWith(actionToExecute.AssertNotNull(nameof(actionToExecute)))
            : source.ConfigureWith(elseActionToExecute);

    /// <summary>
    /// Perform an action on the source then return the source
    /// </summary>
    /// <remarks>
    /// If <paramref name="action"/> is <see langword="null"/> then nothing happens.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static T ConfigureWith<T>(this T source, Action<T>? action)
    {
        action?.Invoke(source);
        return source;
    }
}
