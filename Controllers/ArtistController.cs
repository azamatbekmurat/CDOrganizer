using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CDOrganizer.Models;

namespace CDOrganizer.Controllers
{
  public class ArtistController : Controller
  {
    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/artists/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/artistNames")]
    public ActionResult Create()
    {
      Artist newArtist = new Artist(Request.Form["artist-name"]);
      List<Artist> allArtists = Artist.GetAll();
      return View("Index", allArtists);
    }

    [HttpGet("/artists/{cd}")]
    public ActionResult Details(int cd)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<CD> artistCDs = selectedArtist.GetCDs();
      model.Add("artist", selectedArtist);
      model.Add("cds", artistCDs);
      return View(model);
    }

    [HttpPost("/cds")]
    public ActionResult CreateCD()
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(Int32.Parse(Request.Form["artist-id"]));
      string cdTitle = Request.Form["cd-title"];
      CD newCD = new CD(cdTitle);
      foundArtist.AddCD(newCD);
      List<CD> artistCDs = foundArtist.GetCDs();
      model.Add("cds", artistCDs);
      model.Add("artist", foundArtist);
      return View("Details", model);
    }



  }
}
