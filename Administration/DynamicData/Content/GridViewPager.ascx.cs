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
using System.Web.UI.WebControls;

#endregion

namespace Administration
{
    public partial class GridViewPager : UserControl
    {
        private GridView _gridView;

        protected void Page_Load(object sender, EventArgs e)
        {
            Control c = Parent;
            while (c != null)
            {
                if (c is GridView)
                {
                    _gridView = (GridView) c;
                    break;
                }
                c = c.Parent;
            }
        }

        protected void TextBoxPage_TextChanged(object sender, EventArgs e)
        {
            if (_gridView == null)
            {
                return;
            }
            int page;
            if (int.TryParse(TextBoxPage.Text.Trim(), out page))
            {
                if (page <= 0)
                {
                    page = 1;
                }
                if (page > _gridView.PageCount)
                {
                    page = _gridView.PageCount;
                }
                _gridView.PageIndex = page - 1;
            }
            TextBoxPage.Text = (_gridView.PageIndex + 1).ToString();
        }

        protected void DropDownListPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_gridView == null)
            {
                return;
            }
            DropDownList dropdownlistpagersize = (DropDownList) sender;
            _gridView.PageSize = Convert.ToInt32(dropdownlistpagersize.SelectedValue);
            int pageindex = _gridView.PageIndex;
            _gridView.DataBind();
            if (_gridView.PageIndex != pageindex)
            {
                //if page index changed it means the previous page was not valid and was adjusted. Rebind to fill control with adjusted page
                _gridView.DataBind();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (_gridView != null)
            {
                LabelNumberOfPages.Text = _gridView.PageCount.ToString();
                TextBoxPage.Text = (_gridView.PageIndex + 1).ToString();
                DropDownListPageSize.SelectedValue = _gridView.PageSize.ToString();
            }
        }
    }
}