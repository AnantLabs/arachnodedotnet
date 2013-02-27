﻿#region License : arachnode.net

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

using System;
using System.Web.UI;
using Lucene.Net.Search;

#endregion

namespace Arachnode.Web
{
    public partial class Explanation : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 4 && Request.QueryString.AllKeys[0] == "query" && Request.QueryString.AllKeys[1] == "absoluteUri" && Request.QueryString.AllKeys[2] == "documentID" && Request.QueryString.AllKeys[3] == "strength")
            {
                Query query;

                if (!Request.QueryString.AllKeys[0].Contains(":"))
                {
                    query = Global.DefaultQueryParser.Parse(Request.QueryString.AllKeys[0]);
                }
                else
                {
                    query = Global.CustomQueryParser.Parse(Request.QueryString.AllKeys[0]);
                }

                uxHlAbsoluteUri.NavigateUrl = Request.QueryString[1];
                uxHlAbsoluteUri.Text = Request.QueryString[1];

                Lucene.Net.Search.Explanation explanation = Global.IndexSearcher.Explain(query, int.Parse(Request.QueryString[2]));

                uxLblExplanation.Text = explanation.ToHtml();
                uxLblStrength.Text = "<ul><li>Strength: " + Request.QueryString[3] + "</li></ul>";
            }
        }
    }
}