using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tracker.Web.Models;
using Tracker.Core;
using Tracker.Core.Models;
using Tracker.Core.Interfaces;


namespace Tracker.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDayRecordRepository _repo;

    public HomeController(ILogger<HomeController> logger, IDayRecordRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var allRecords = _repo.GetAllRecords();
        return View(allRecords);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    [HttpPost]
    public IActionResult Add(DateOnly recordDate)
    {
        var newRecord = new DayRecord
        {
            RecordDate = recordDate
        };

        _repo.AddRecord(newRecord);
        return RedirectToAction("Index");
    }
}
