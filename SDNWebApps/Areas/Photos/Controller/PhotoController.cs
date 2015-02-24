using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace SDNWebApps.Areas.Photos.Controllers
{
    public class PhotoController : Controller
    {
        public ActionResult Index(string addlocation = "",int photoLocationNumber = 0)
        {
            Models.PhotoViewModel pvm = new Models.PhotoViewModel();

            if (!addlocation.Equals(""))
            {
                pvm.CurrentLocation = addlocation;
            }

            if (pvm.CurrentLocation.Length < pvm.TopRoot.Length)
                    pvm.CurrentLocation = pvm.TopRoot;


            pvm.Folders = System.IO.Directory.GetDirectories(pvm.CurrentLocation).ToList<string>();

            pvm.ImageLocations = Directory.GetFiles(pvm.CurrentLocation).Where(m =>
                m.ToLower().EndsWith("jpg") || m.ToLower().EndsWith("png")).ToList();

            pvm.PhotoLocationNumber += photoLocationNumber;
            pvm.TotalPages = pvm.ImageLocations.Count/6;

            pvm.Images.Clear();

            

            for (int i = photoLocationNumber; i <= pvm.PhotoLocationNumber+5 && pvm.ImageLocations.Count-1 >=i; i++)
            {
                string image = pvm.ImageLocations[i];

                Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                Bitmap myBitmap = new Bitmap(image);
                Image myThumbnail = myBitmap.GetThumbnailImage(75, 75, myCallback, IntPtr.Zero);
                //pvm.RealImages.Add(myThumbnail);

                ImageConverter _imageConverter = new ImageConverter();
                byte[] xByte = (byte[])_imageConverter.ConvertTo(myThumbnail, typeof(byte[]));
                
                Models.ImageFile ifModel = new Models.ImageFile();
                

                FileInfo currentFile = new FileInfo(image);

                ifModel.Name = currentFile.FullName;
                ifModel.Data = xByte;

                pvm.Images.Add(ifModel);
            }

            return View(pvm);
        }

        public ActionResult ViewPhoto(string photolocation = "")
        {
            return View();
        }

        public bool ThumbnailCallback()
        {
            return false;
        }


    }
}
