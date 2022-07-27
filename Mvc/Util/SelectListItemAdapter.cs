using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;


namespace Mvc.Util
{
    public static class SelectListItemAdapter
    {
        // for text-value pair select options
        public static IEnumerable<SelectListItem> ConvertToSelectListItemCollection<T>(
            IEnumerable<T> source,
            Func<T, string> text,
            Func<T, string> value,
            bool createEmpty = true) where T : class
        {
            List<SelectListItem> selectListItems = new();

            if (createEmpty) selectListItems.Add(new SelectListItem { Text = "Please Select", Value = "", Selected = true });

            foreach (var item in source) selectListItems.Add(new SelectListItem { Text = text(item), Value = value(item) });

            return selectListItems;
        }

        // for text-text/value-value select options
        public static IEnumerable<SelectListItem> ConvertToSelectListItemCollection<T>(
            IEnumerable<T> source,
            Func<T, string> textAndValue,
            bool createEmpty = true) where T : class
        {
            return ConvertToSelectListItemCollection(source, textAndValue, textAndValue, createEmpty);
        }
    }
}
