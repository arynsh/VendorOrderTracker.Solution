using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      System.Console.WriteLine("HomeController");
      return View();
    }

  }
}