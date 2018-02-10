using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Web.Models
{
    public class MessegeViewModel
    {
        public MessegeViewModel()
        {
        }

        public MessegeViewModel(string from, string to)
        {
            From = from;
            To = to;
            
        }
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }

    }
}