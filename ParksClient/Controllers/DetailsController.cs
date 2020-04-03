using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParksClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ParksClient.Controllers
{
  public class DetailsController : Controller
  {
    public IActionResult Index()
    {
      var allDetails = Detail.Get();
      return View(allDetails);
    }

    [HttpPost]
    public IActionResult Index(Detail detail)
    {
      Detail.Post(detail);
      return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
      ViewBag.ParkId = new SelectList(Park.GetParks(), "ParkId", "Management");
      return View();
    }

    [HttpPost]
    public IActionResult Create(Detail detail)
    {
      Detail.Post(detail);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var detail = Detail.GetDetails(id);
      return View(detail);
    }

    public IActionResult Edit(int id)
    {
      var detail = Detail.GetDetails(id);
      return View(detail);
    }

    [HttpPost]
    public IActionResult Details(int id, Detail detail)
    {
      detail.DetailId = id; 
      Detail.Put(detail);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      var detail = Detail.GetDetails(id);
      return View(id);
    }

    [HttpPost, ActManagement("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
      Detail.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
