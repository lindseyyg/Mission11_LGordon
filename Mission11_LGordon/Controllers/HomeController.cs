using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Mission11_LGordon.Models;
using Mission11_LGordon.Models.ViewModels;


namespace Mission11_LGordon.Controllers;

public class HomeController : Controller
{
    private IBookstoreRepository _repo;

    public HomeController(IBookstoreRepository temp)
    {
        _repo = temp;
    }
    public IActionResult Index(int pageNum, string Category)
    {
        int pageSize = 10;
        
        var x = new BooksListViewModel
        {
            Books = _repo.Books
                .Where(x => x.Category == Category || Category == null)
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

            PaginationInfo = new PaginationInfo
            {
                CurrentPage = pageNum,
                ItemsPerPage = pageSize,
                // If statement - if category is null do this, else do that
                TotalItems = Category == null ? _repo.Books.Count() : _repo.Books.Where(x => x.Category == Category).Count()
            },
            
            CurrentBookCategory = Category
                
        }
        ;
        return View(x);
    }
}