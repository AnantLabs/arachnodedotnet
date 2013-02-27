#region License : arachnode.net

// // Copyright (c) 2013 http://arachnode.net, arachnode.net, LLC
// //  
// // Permission is hereby granted, upon purchase, to any person
// // obtaining a copy of this software and associated documentation
// // files (the "Software"), to deal in the Software without
// // restriction, including without limitation the rights to use,
// // copy, merge and modify copies of the Software, and to permit persons
// // to whom the Software is furnished to do so, subject to the following
// // conditions:
// // 
// // LICENSE (ALL VERSIONS/EDITIONS): http://arachnode.net/r.ashx?3
// // 
// // The above copyright notice and this permission notice shall be
// // included in all copies or substantial portions of the Software.
// // 
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// // EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// // OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// // NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// // HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// // WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// // FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// // OTHER DEALINGS IN THE SOFTWARE.

#endregion

#region

using System.Collections.Generic;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

#endregion

public partial class UserDefinedFunctions
{
    /// <summary>
    /// 	Generates the repeated keystroke typos.
    /// </summary>
    /// <param name = "term">The term.</param>
    /// <param name = "maximumNumberOfRepeatedKeystrokes">The maximum number of repeated keystrokes.</param>
    /// <returns></returns>
    [SqlFunction]
    [return: SqlFacet(MaxSize = -1)]
    public static SqlString GenerateRepeatedKeystrokeTypos(string term, int maximumNumberOfRepeatedKeystrokes)
    {
        List<string> typographicalErrors = new List<string>();

        typographicalErrors.Add(term.ToLower());

        for (int i = 1; i <= maximumNumberOfRepeatedKeystrokes; i++)
        {
            int typographicalErrorsCount = typographicalErrors.Count;

            for (int j = 0; j < typographicalErrorsCount; j++)
            {
                for (int k = 0; k < typographicalErrors[j].Length; k++)
                {
                    string typographicalError = typographicalErrors[j].Substring(0, k) + typographicalErrors[j].Substring(k, 1) + typographicalErrors[j].Substring(k, typographicalErrors[j].Length - k);

                    if (!typographicalErrors.Contains(typographicalError))
                    {
                        typographicalErrors.Add(typographicalError);
                    }
                }
            }
        }

        typographicalErrors.Remove(term.ToLower());

        return ConvertTypographicalErrorsToString(typographicalErrors);
    }
} ;