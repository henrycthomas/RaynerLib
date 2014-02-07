using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Rayner.Extensions.Razor
{
    static class HtmlHelpers
    {
        public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper htmlHelper, string name, TEnum selectedValue, Dictionary<string, object> htmlattributes = null, string emptyEntry = "", bool camelSplit = true)
        {
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            IEnumerable<SelectListItem> items = from value in values select new SelectListItem { Text = value.ToString().InsertCamelCaseSpaces(), Value = value.ToString(), Selected = (string.IsNullOrWhiteSpace(emptyEntry) && value.Equals(selectedValue)) };

            var l = new List<SelectListItem>();
            if (!string.IsNullOrWhiteSpace(emptyEntry))
            {
                l.Add(new SelectListItem { Text = emptyEntry, Value = "-1", Selected = true });
            }
            l.AddRange(items);

            return htmlHelper.DropDownList(name, l, htmlattributes);
        }
        public static MvcHtmlString EmailLink(this HtmlHelper htmlHelper, string email, string subject, string cc, string bcc)
        {
            return new MvcHtmlString(string.Format("<a href=\"mailto:{0}?subject={1}&cc={2}&bcc={3}\">{0}</a>", email, subject, cc, bcc));
        }
        public static MvcHtmlString ElipseString(this HtmlHelper htmlHelper, string s, int length)
        {
            var r = s;
            if (s.Length > length)
            {
                r = s.Substring(0, length) + "...";
            }
            return new MvcHtmlString(r);
        }
        public static MvcHtmlString IfShowMe(this HtmlHelper htmlHelper, bool showMe, string s)
        {
            return showMe ? new MvcHtmlString(s) : new MvcHtmlString("");
        }
    }
}
