﻿#region License : arachnode.net

// Copyright (c) 2012 http://arachnode.net, arachnode.net, LLC
//  
// Permission is hereby granted, upon purchase, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, merge and modify copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following
// conditions:
// 
// LICENSE (ALL VERSIONS/EDITIONS): http://arachnode.net/r.ashx?3
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

#endregion

namespace Arachnode.Renderer.Value.Enums
{
    public enum ReadyState
    {
        // Summary:
        //     No document is currently loaded.
        Uninitialized = 0,
        //
        // Summary:
        //     The control is loading a new document.
        Loading = 1,
        //
        // Summary:
        //     The control has loaded and initialized the new document, but has not yet
        //     received all the document data.
        Loaded = 2,
        //
        // Summary:
        //     The control has loaded enough of the document to allow limited user interaction,
        //     such as clicking hyperlinks that have been displayed.
        Interactive = 3,
        //
        // Summary:
        //     The control has finished loading the new document and all its contents.
        Complete = 4,
    }
}