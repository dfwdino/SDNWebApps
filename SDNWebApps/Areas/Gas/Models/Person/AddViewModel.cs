using System.Collections.Generic;

namespace SDNWebApps.Areas.Gas.Models.Person
{
    public class AddViewModel
    {

        public AddViewModel()
        {

        }

        public AddViewModel(string personname)
        {
            Personname = personname;
        }

        public string Personname { get; set; }

    }

    

}