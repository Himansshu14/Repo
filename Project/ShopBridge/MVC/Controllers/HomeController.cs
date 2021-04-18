using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<MVCProductModel> prodlist;
            HttpResponseMessage response = GlobalVariable.webclient.GetAsync("http://localhost:51729/api/ShopBridgeProducts").Result;
            prodlist = response.Content.ReadAsAsync<IEnumerable<MVCProductModel>>().Result;
            return View(prodlist);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MVCProductModel model)
        {
            HttpResponseMessage response = GlobalVariable.webclient.PostAsJsonAsync("http://localhost:51729/api/ShopBridgeProducts",model).Result;

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            HttpResponseMessage response = GlobalVariable.webclient.GetAsync("http://localhost:51729/api/ShopBridgeProducts/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<MVCProductModel>().Result);

        }
        [HttpPost]
        public ActionResult Edit(MVCProductModel model)
        {
            HttpResponseMessage httpResponseMessage = GlobalVariable.webclient.PutAsJsonAsync("http://localhost:51729/api/ShopBridgeProducts/" +model.ProductId, model).Result;
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage httpResponseMessage = GlobalVariable.webclient.DeleteAsync("http://localhost:51729/api/ShopBridgeProducts/" + id).Result;
            return RedirectToAction("Index");
            // return View(httpResponseMessage.Content.ReadAsAsync<MVCProductModel>().Result);
        }
    }
}