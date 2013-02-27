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
using System.Collections.Generic;
using Arachnode.DataAccess;
using Arachnode.SiteCrawler.Value;
using Arachnode.SiteCrawler.Value.AbstractClasses;

#endregion

namespace Arachnode.Plugins.CrawlRules
{
    public class LastModified : ACrawlRule
    {
        private int _maximumTotalHoursOld;

        public override void AssignSettings(Dictionary<string, string> settings)
        {
            _maximumTotalHoursOld = int.Parse(settings["MaximumTotalHoursOld"]);
        }

        public override bool IsDisallowed(CrawlRequest crawlRequest, ArachnodeDAO arachnodeDAO)
        {
            if (crawlRequest.WebClient != null && crawlRequest.WebClient.HttpWebResponse != null)
            {
                if (DateTime.Now.Subtract(crawlRequest.WebClient.HttpWebResponse.LastModified).TotalHours > _maximumTotalHoursOld)
                {
                    crawlRequest.Discovery.IsDisallowedReason = "More than maximum total hours old.";

                    return true;
                }
            }

            return false;
        }

        public override bool IsDisallowed(Discovery discovery, ArachnodeDAO arachnodeDAO)
        {
            return false;
        }


        public override void Stop()
        {
        }
    }
}