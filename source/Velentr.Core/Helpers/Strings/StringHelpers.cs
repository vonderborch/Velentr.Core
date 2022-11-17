using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

using Velentr.Core.Helpers.Validation;

namespace Velentr.Core.Helpers.Strings
{
    /// <summary>
    ///     Helpers when dealing with strings.
    /// </summary>
    public static class StringHelpers
    {
        /// <summary>
        ///     (Immutable) the new line characters.
        /// </summary>
        private static readonly string[] _newLineChars = {"\r\n", "\r", "\n"};

        /// <summary>
        ///     Formats a string based on positional naming (ala https://messagetemplates.org/) or indexes
        ///     (ala string.Format()).
        /// </summary>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        /// <param name="str">          The string. </param>
        /// <param name="parameters">   The parameters. </param>
        /// <returns>
        ///     The formatted string.
        /// </returns>
        public static string FormatString(string str, params object[] parameters)
        {
            // go through the string and assemble the actual output string
            var parameterIndexMapping = new Dictionary<string, int>();
            var parameterMappingSerialized = new Dictionary<string, string>(parameters.Length);
            var parameterMappingString = new Dictionary<string, string>(parameters.Length);
            var outputString = new StringBuilder();
            var currentParameterIndex = 0;
            for (var i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '{':
                        if (i != 0 && str[i - 1] == '\\')
                        {
                            outputString.Append(str[i]);
                        }
                        else
                        {
                            var actualNameIndex = i + 1;
                            var serializeParameter = false;
                            if (str[actualNameIndex] == '@')
                            {
                                serializeParameter = true;
                                actualNameIndex++;
                            }

                            var parameterLength = str.Substring(actualNameIndex).IndexOf('}');
                            if (parameterLength == -1)
                            {
                                outputString.Append(str[i]);

                                break;
                            }

                            var parameterName = str.Substring(actualNameIndex, parameterLength).ToUpperInvariant();
                            var parameterValue = string.Empty;
                            if (int.TryParse(parameterName, out var paramIndex))
                            {
                                if (parameters.Length > paramIndex && paramIndex >= 0)
                                {
                                    parameterValue = serializeParameter ? JsonConvert.SerializeObject(parameters[paramIndex]) : parameters[paramIndex].ToString();
                                    parameterName = paramIndex.ToString();
                                }
                                else
                                {
                                    throw new Exception("Invalid parameter position!");
                                }
                            }
                            else
                            {
                                var index = 0;
                                if (serializeParameter)
                                {
                                    if (!parameterMappingSerialized.ContainsKey(parameterName))
                                    {
                                        if (!parameterIndexMapping.TryGetValue(parameterName, out index))
                                        {
                                            index = currentParameterIndex++;
                                            parameterIndexMapping.Add(parameterName, index);
                                        }

                                        parameterValue = JsonConvert.SerializeObject(parameters[index]);
                                    }
                                }
                                else
                                {
                                    if (!parameterMappingString.ContainsKey(parameterName))
                                    {
                                        if (!parameterIndexMapping.TryGetValue(parameterName, out index))
                                        {
                                            index = currentParameterIndex++;
                                            parameterIndexMapping.Add(parameterName, index);
                                        }

                                        parameterValue = parameters[index].ToString();
                                    }
                                }
                            }

                            if (serializeParameter)
                            {
                                if (!parameterMappingSerialized.ContainsKey(parameterName))
                                {
                                    parameterMappingSerialized[parameterName] = parameterValue;
                                }

                                outputString.Append(parameterMappingSerialized[parameterName]);
                            }
                            else
                            {
                                if (!parameterMappingString.ContainsKey(parameterName))
                                {
                                    parameterMappingString[parameterName] = parameterValue;
                                }

                                outputString.Append(parameterMappingString[parameterName]);
                            }

                            i += parameterLength + 1;
                        }

                        break;

                    default:
                        outputString.Append(str[i]);

                        break;
                }
            }

            return outputString.ToString();
        }

        /// <summary>
        ///     Splits a string into chunks based on the provided size of the chunks.
        /// </summary>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        /// <param name="str">          The string. </param>
        /// <param name="chunkSize">    Size of the chunk. </param>
        /// <returns>
        ///     The string chunks.
        /// </returns>
        /// ###
        /// <exception cref="System.Exception">
        ///     Chunk size must be a positive number of at least 1.
        ///     Chunk size requested: [{chunkSize}].
        /// </exception>
        public static IEnumerable<string> SplitStringByChunkSize(string str, int chunkSize)
        {
            if (chunkSize <= 0)
            {
                throw new Exception($"Chunk size must be a positive number of at least 1. Chunk size requested: [{chunkSize}]");
            }

            for (var i = 0; i < str.Length; i += chunkSize)
            {
                yield return str.Substring(i, System.Math.Min(chunkSize, str.Length - i));
            }
        }

        /// <summary>
        ///     Enumerates split string by new lines in this collection.
        /// </summary>
        /// <param name="str">  The string. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process split string by new lines in this
        ///     collection.
        /// </returns>
        public static IEnumerable<string> SplitStringByNewLines(string str)
        {
            return str.Split(_newLineChars, StringSplitOptions.None);
        }

        /// <summary>
        ///     Gets blank string.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when one or more arguments are outside
        ///     the required range.
        /// </exception>
        /// <param name="numberOfSpaces">   (Optional) Number of spaces. </param>
        /// <returns>
        ///     The blank string.
        /// </returns>
        public static string GetBlankString(int numberOfSpaces = 1)
        {
            Validations.ValidateRange(numberOfSpaces, nameof(numberOfSpaces), 0);

            return new string(' ', numberOfSpaces);
        }
    }
}
