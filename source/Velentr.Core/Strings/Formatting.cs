using System.Reflection;
using System.Text;
using Velentr.Core.Json;

namespace Velentr.Core.Strings;

/// <summary>
///     Provides methods for formatting strings with placeholders and parameters.
/// </summary>
public static class Formatting
{
    /// <summary>
    ///     Appends a parameter to the output format string.
    /// </summary>
    /// <param name="outputFormatString">The output format string.</param>
    /// <param name="paramStringParts">The parts of the parameter string.</param>
    /// <param name="paramIndex">The index of the parameter.</param>
    private static void AppendParameter(StringBuilder outputFormatString, string[] paramStringParts, int paramIndex)
    {
        if (paramStringParts.Length == 2)
        {
            outputFormatString.Append($"{{{paramIndex}:{paramStringParts[1]}}}");
        }
        else
        {
            outputFormatString.Append($"{{{paramIndex}}}");
        }
    }

    /// <summary>
    ///     Formats a parameter value.
    /// </summary>
    /// <param name="param">The parameter value.</param>
    /// <param name="paramMode">Indicates whether the parameter should be serialized.</param>
    /// <returns>The formatted parameter value.</returns>
    private static object FormatParameter(object? param, bool? paramMode)
    {
        if (param == null)
        {
            return "";
        }

        switch (paramMode)
        {
            case true:
                return JsonHelpers.SerializeToString(param);
            case false:
                return param.ToString() ?? "";
            default:
                return param;
        }
    }

    /// <summary>
    ///     Formats a string by replacing placeholders with the provided parameters.
    ///     Based heavily on the rules of: https://messagetemplates.org/
    /// </summary>
    /// <param name="value">The format string containing placeholders.</param>
    /// <param name="parameters">The parameters to replace the placeholders.</param>
    /// <returns>The formatted string.</returns>
    public static string FormatString(string value, params object?[]? parameters)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        if (parameters == null)
        {
            parameters = [null];
        }

        List<object> finalParameters = new();
        Dictionary<string, int> parameterIndexMap = new();
        StringBuilder outputFormatString = new(value.Length);

        bool? evenBraces = null;
        var i = 0;

        while (i < value.Length)
        {
            if (value[i] == '{')
            {
                evenBraces = evenBraces == null ? false : !evenBraces;
                if (evenBraces == true)
                {
                    outputFormatString.Append("{{");
                    evenBraces = null;
                }

                i++;
            }
            else
            {
                if (evenBraces == true)
                {
                    outputFormatString.Append($"{{{value[i]}");
                    i++;
                }
                else if (evenBraces == null)
                {
                    outputFormatString.Append(value[i]);
                    i++;
                }
                else
                {
                    i = ProcessParameter(value, parameters, finalParameters, parameterIndexMap, outputFormatString, i);
                    evenBraces = null;
                }
            }
        }

        var finalFormatString = outputFormatString.ToString();
        object?[] finalParametersArray = finalParameters.ToArray();
        var output = string.Format(finalFormatString, finalParametersArray);
        return output;
    }

    /// <summary>
    ///     Gets the value of a parameter.
    /// </summary>
    /// <param name="paramKey">The key of the parameter.</param>
    /// <param name="parameters">The parameters to replace the placeholders.</param>
    /// <param name="baseParamKey">The base key of the parameter.</param>
    /// <param name="paramMode">Indicates whether the parameter should be serialized.</param>
    /// <returns>The value of the parameter.</returns>
    private static object GetParameterValue(string paramKey, object[] parameters, out string baseParamKey,
        out bool? paramMode)
    {
        paramMode = null;
        baseParamKey = paramKey;

        if (paramKey.StartsWith("@"))
        {
            paramMode = true;
            paramKey = paramKey.Substring(1);
        }
        else if (paramKey.StartsWith("$"))
        {
            paramMode = false;
            paramKey = paramKey.Substring(1);
        }

        if (int.TryParse(paramKey, out var paramIndexInt))
        {
            if (parameters.Length > paramIndexInt && paramIndexInt >= 0)
            {
                return parameters[paramIndexInt];
            }

            throw new ArgumentException($"Invalid parameter position `{paramIndexInt}`!");
        }

        foreach (var parameter in parameters)
        {
            PropertyInfo? property = parameter.GetType().GetProperty(paramKey);
            if (property != null)
            {
                return property.GetValue(parameter);
            }
        }

        return "";
    }

    /// <summary>
    ///     Processes a parameter in the format string.
    /// </summary>
    /// <param name="value">The format string.</param>
    /// <param name="parameters">The parameters to replace the placeholders.</param>
    /// <param name="finalParameters">The list of final parameters.</param>
    /// <param name="parameterIndexMap">The map of parameter indices.</param>
    /// <param name="outputFormatString">The output format string.</param>
    /// <param name="i">The current index in the format string.</param>
    /// <returns>The updated index in the format string.</returns>
    private static int ProcessParameter(string value, object[] parameters, List<object> finalParameters,
        Dictionary<string, int> parameterIndexMap, StringBuilder outputFormatString, int i)
    {
        var startIndex = i;
        while (value[i] != '}')
        {
            i++;
        }

        var paramString = value.Substring(startIndex, i - startIndex);
        var paramStringParts = paramString.Split(new[] { ':' }, 2);
        var paramKey = paramStringParts[0];

        if (parameterIndexMap.TryGetValue(paramKey, out var paramIndex))
        {
            AppendParameter(outputFormatString, paramStringParts, paramIndex);
        }
        else
        {
            var param = GetParameterValue(paramKey, parameters, out var baseParamKey, out var paramMode);
            param = FormatParameter(param, paramMode);
            finalParameters.Add(param);
            parameterIndexMap.Add(baseParamKey, finalParameters.Count - 1);
            AppendParameter(outputFormatString, paramStringParts, finalParameters.Count - 1);
        }

        return i + 1;
    }

    /// <summary>
    ///     Formats a string by replacing placeholders with the provided parameters.
    ///     Based heavily on the rules of: https://messagetemplates.org/
    /// </summary>
    /// <param name="value">The format string containing placeholders.</param>
    /// <param name="parameters">The parameters to replace the placeholders.</param>
    /// <returns>The formatted string.</returns>
    public static string TemplateFormat(this string value, params object?[]? parameters)
    {
        return FormatString(value, parameters);
    }
}
