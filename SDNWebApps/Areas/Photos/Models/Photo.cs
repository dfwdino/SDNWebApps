using System.Collections.Generic;
using System.Drawing;

namespace SDNWebApps.Areas.Photos.Models
{
    public class PhotoViewModel
    {
        public string CurrentLocation { get; set; }

        public List<string> Folders { get; set; }

        public List<ImageFile> Images { get; set; }

        public List<string> ImageLocations { get; set; } 

        public int PhotoLocationNumber { get; set; }

        public List<Image> RealImages { get; set; }

        public string TopRoot { get; set; }
               

        public PhotoViewModel()
        {   
            CurrentLocation = @"E:\all backup\images\Personal\Clean";
            TopRoot = CurrentLocation;
            Folders = new List<string>();
            Images = new List<ImageFile>();
            RealImages = new List<Image>();
            PhotoLocationNumber = 0;

        }

    }
}