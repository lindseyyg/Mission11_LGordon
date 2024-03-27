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
    public IActionResult Index(int pageNum)
    {
        int pageSize = 10;
        
        var x = new BooksListViewModel
        {
            Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

            PaginationInfo = new PaginationInfo
            {
                CurrentPage = pageNum,
                ItemsPerPage = pageSize,
                TotalItems = _repo.Books.Count()
            }
        }
        ;
        return View(x);
    }
}