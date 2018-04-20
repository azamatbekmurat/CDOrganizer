using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CDOrganizer.Models;
using System;

namespace CDOrganizer.Controllers
{
  public class HomePageController : Controller
  {
    [HttpGet("/")]
    public ActionResult HomePage()
    {
      return View();
    }

  }
}
