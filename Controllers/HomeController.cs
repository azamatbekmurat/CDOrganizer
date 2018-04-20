using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CDOrganizer.Models;
using System;

namespace CDOrganizer.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/cds")]
    public ActionResult Index()
    {
      List<CD> allCDs = CD.GetAll();
      return View(allCDs);
    }

    [HttpGet("/artists/{artistId}/cds/new")]
    public ActionResult CreateForm(int artistId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist artist = Artist.Find(artistId);
      return View(artist);
    }

    [HttpGet("/artists/{artistId}/cds/{cdId}")]
    public ActionResult Details(int artistId, int cdId)
    {
      CD cd = CD.Find(cdId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist artist = Artist.Find(artistId);
      model.Add("cd", cd);
      model.Add("artist", artist);
      return View(cd);
    }

    // [HttpGet("/cds/new")]
    // public ActionResult CreateForm()
    // {
    //   return View();
    // }
    //
    // [HttpPost("/cds")]
    // public ActionResult Create()
    // {
    //
    //   CD newCD = new CD (Request.Form["cd-title"], Request.Form["cd-genre"]);
    //   List<CD> allCDs = CD.GetAll();
    //   return View("Index", allCDs);
    // }
    //
    // [HttpGet("/cds/{id}")]
    // public ActionResult Details(int id)
    // {
    //   CD cd = CD.Find(id);
    //   return View(cd);
    // }

    [HttpPost("/cds/delete")]
    public ActionResult DeleteAll()
    {
      CD.ClearAll();
      return View();
    }
  }
}
