using EnFu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace EnFu.Helpers
{
    public static class TextHelper
    {
        public static string GetSearchText(SearchType searchType)
        {
            return GetDescription<SearchType>(searchType.ToString());
        }
        private static string GetDescription<T>(string fieldName)
        {
            string result;
            FieldInfo fi = typeof(T).GetField(fieldName.ToString());
            if (fi != null)
            {
                try
                {
                    object[] descriptionAttrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    DescriptionAttribute description = (DescriptionAttribute)descriptionAttrs[0];
                    result = (description.Description);
                }
                catch
                {
                    result = null;
                }
            }
            else
            {
                result = null;
            }

            return result;
        }
    }
}