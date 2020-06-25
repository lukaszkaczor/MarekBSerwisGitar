using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SerwisGitar.Models;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.Models
{
    public class GalleryManager
    {
        private readonly ApplicationDbContext _context;

        public GalleryManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ImageGallery> SetOrderOfImageGalleries(ImageGallery imageGallery)
        {
            if (imageGallery == null || _context == null) throw new NullReferenceException();


            if (imageGallery.Order < 1)
                imageGallery.Order = 1;

            var imageGalleries = _context.ImageGalleries
                .Where(d => d.GalleryId == imageGallery.GalleryId)
                .OrderBy(d => d.Order).ToList();

            var thisGallery = imageGalleries
                .Where(d => d.ImageId == imageGallery.ImageId)
                .SingleOrDefault(d => d.Order == imageGallery.Order);

            if (thisGallery == null) throw new NullReferenceException();

            imageGalleries.Remove(thisGallery);

            if (imageGallery.Order > imageGalleries.Max(d => d.Order))
                thisGallery.Order = imageGalleries.Max(d => d.Order) + 1;

            if (imageGalleries.Count > 0) 
                imageGalleries.Insert(imageGallery.Order - 1 ?? imageGalleries.Count, thisGallery);
            else
                imageGalleries.Add(imageGallery);
            

            return OrderAndSave(imageGalleries);
        }

        public List<ImageGallery> OrderAndSave(List<ImageGallery> imageGalleries)
        {
            if (imageGalleries == null) throw new NullReferenceException();

            for (var i = 0; i < imageGalleries.Count; i++)
                imageGalleries[i].Order = i + 1;

            _context.SaveChanges();

            return imageGalleries;
        }
    }
}
