using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAMT2P.Models;

namespace TEAMT2P.Helpers
{
    public class WatchList
    {
        public List<WLItem> Items { get; set; }
        public WatchList()
        {
            this.Items = new List<WLItem>();
        }

        public void AddItem(WLItem item)
        {
            this.Items.Add(item);
        }
    }

    public class WLItem
    {
        public Product Product { get; set; }
    }
}