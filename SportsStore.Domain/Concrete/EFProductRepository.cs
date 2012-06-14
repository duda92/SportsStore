using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.IO;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        #region IProductRepository Members

        public IQueryable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }

        #endregion
    }
}




        //public EFProductRepository()
        //{
        //    byte[] imageData = null;
        //    using (FileStream imageFile = File.Open(@"D:\Practice\SvnLocalDir\SportsStore\DB\mini_soccer_ball.jpg", FileMode.Open))
        //    {
        //        imageData = new byte[imageFile.Length];
        //        imageFile.Read(imageData, 0, imageData.Length);
        //    }
        //    context.Products.Add(new Product { Category = "Football", Name = "adidas MLS 2012 Prime Mini Soccer Ball", Price = 11.99M, Description = "Mini Soccer Balls - Need something to pass the time, or a great conversation piece? A mini soccer ball from World Soccer Shop is just what you need. Also a great gift idea, a mini soccer ball from World Soccer Shop will bring a smile to that little soccer fanatic in your life.", Image = imageData });
        //    context.SaveChanges();
        //}