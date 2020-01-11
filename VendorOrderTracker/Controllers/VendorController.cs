using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;

namespace Tracker.Controllers
{
  public class VendorController : Controller
  {

    [HttpGet("/vendor")]
    public ActionResult Index()
    {
      List<Vendor> allvendor = Vendor.GetAll();
      return View(allvendor);
    }

    [HttpGet("/vendor/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendor")]
    public ActionResult Create(string VendorName, string Description)
    {
      System.Console.WriteLine("vendorControllerCreateMethod");
      Vendor newVendor = new Vendor(VendorName, Description);
      return RedirectToAction("Index", "/");
    }

    [HttpGet("/vendor/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendororders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("orders", vendororders);
      return View(model);
    }

    // This one creates new orders within a given Vendor, not new vendor:
    [HttpPost("/vendor/{VendorId}/orders")]
    public ActionResult Create(int VendorId, string orderDate, string orderDescription, double orderPrice)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(VendorId);
      Order neworder = new Order(orderDate, orderDescription, orderPrice);
      foundVendor.AddOrder(neworder);
      List<Order> Vendororders = foundVendor.Orders;
      model.Add("orders", Vendororders);
      model.Add("vendor", foundVendor);
      return View("Show", model);
    }

  }
}