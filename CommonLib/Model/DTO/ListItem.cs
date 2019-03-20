using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Model.DTO
{
    [Serializable]
    public class ListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ListItem()
        {

        }

        public ListItem(string value, string text)
        {
            this.Value = value;
            this.Text = text;
        }
    }

    [Serializable]
    public class ListItemEx
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ListItemEx()
        {

        }

        public ListItemEx(string value, string text)
        {
            this.Value = value;
            this.Text = text;
        }
    }
}
