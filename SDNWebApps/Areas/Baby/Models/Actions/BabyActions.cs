using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Baby.Models.Actions
{
    public partial class BabyActions : Views.Actions
    {
        public BabyActions()
        {
            
        }
        [DisplayName("Category")]
        public ActionCategory ActionCategory { get; set; }

    }
}