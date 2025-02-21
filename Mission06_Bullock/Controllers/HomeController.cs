using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Bullock.Models;

namespace Mission06_LastName.Controllers;

public class HomeController : Controller
{
    private AddMovieContext _context;

    public HomeController(AddMovieContext temp)
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult FindOutAboutJoel()
    {
        return View("MeetJoel");
    }
    
    [HttpGet]
    public IActionResult AddMovie()
    {
        ViewBag.Category = _context.Category
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("AddMovie");
    }

    [HttpPost]
    public IActionResult AddMovie(Application response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();
        

        return View("Confirmation",response);
    }

    public IActionResult MovieList()
    {
        var applications = _context.Movies
            .Include(m=>m.Category)
            .ToList();
        return View(applications);
    }
    
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Category = _context.Category
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("AddMovie", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Application updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Application application)
    {
        _context.Movies.Remove(application);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }

}