﻿using Bai10_OnlineShhop.Common;
using Bai10_OnlineShhop.Models;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Bai10_OnlineShhop.Controllers
{
    public class HomeController : Controller
    {
      
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(4);
            ViewBag.ListFeatureProducts = productDao.ListFeatureProduct(4);

            // set seo title
            ViewBag.Title = ConfigurationManager.AppSettings["HomeTitle"];
            ViewBag.Keywords = ConfigurationManager.AppSettings["HomeKeyword"];
            ViewBag.Descriptions = ConfigurationManager.AppSettings["HomeDescriptions"];
            return View();
        }
        [ChildActionOnly]
        [OutputCache(Duration =3600*24)]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            
            return PartialView(list);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600*24)]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }
    }
}