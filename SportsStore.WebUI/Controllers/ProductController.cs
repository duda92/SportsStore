using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public int PageSize = 4;
        public string currentCategory;
        public IEnumerable<Product> productsForDisplay;
        public PagingInfo pagingInfo;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
        {
            productsForDisplay = repository.Products.Where(p => category == null || p.Category == category).OrderBy(x => x.ProductId).Skip((page - 1) * PageSize).Take(PageSize);
            pagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = repository.Products.Where(p => category == null || p.Category == category).OrderBy(x => x.ProductId).Count() };
            
            ProductListViewModel viewModel = new ProductListViewModel
            {
                Products = productsForDisplay,
                PagingInfo = pagingInfo
            };
            currentCategory = category;
            return View(viewModel);
        }

    }
}
