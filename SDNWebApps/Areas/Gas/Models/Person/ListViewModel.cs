using System.Collections.Generic;

namespace SDNWebApps.Areas.Gas.Models.Person
{
    public class ListViewModel
    {
        public ListViewModel(List<SDNWebApps.Views.Person> persons)
        {
            Persons = persons;
        }

        public List<SDNWebApps.Views.Person> Persons { get; set; }

    }

    

}