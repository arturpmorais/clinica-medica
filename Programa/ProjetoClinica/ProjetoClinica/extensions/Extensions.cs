﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProjetoClinica.extensions
{
    public static class Extensions
    {
        public static bool IsEmptyString(this string s)
        {
            if (s == null || s.Trim() == "")
                return true;

            return false;
        }

        public static List<ListItem> GetSelectedItems(this ListBox list)
        {

            List<ListItem> ret = new List<ListItem>();

            foreach (ListItem item in list.Items)
                if (item.Selected)
                    ret.Add(item);

            return ret;
        }
    }
}