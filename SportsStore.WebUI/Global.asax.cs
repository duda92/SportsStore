﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SportsStore.WebUI.Infrastructure;

namespace SportsStore.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                    "",
                    new 
                    { 
                        controller = "Product",
                        action = "List",
                        category = (string) null,
                        page = 1
                    }
                );

            routes.MapRoute(null,
                    "Page{page}",
                    new
                    {
                        controller = "Product",
                        action = "List",
                        category = (string)null
                    },
                    new 
                    { 
                        page = @"\d+"
                    }
                );

            routes.MapRoute(null,
                    "{category}",
                    new
                    {
                        controller = "Product",
                        action = "List",
                        page = 1
                    },
                    new
                    {
                        page = @"\d+"
                    }
                );

            routes.MapRoute(null,
                    "{category}/Page{page}",
                    new
                    {
                        controller = "Product",
                        action = "List"
                    },
                    new
                    {
                        page = @"\d+"
                    }
                );

            routes.MapRoute(
                            null, // Route name
                            "Page{page}", // URL with parameters
                            new { controller = "Product", action = "List" } // Parameter defaults
                        );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}