using Microsoft.AspNetCore.Mvc;
using Mission11_LGordon.Models;

namespace Mission11_LGordon.Components;

public class BookTypesViewComponent : ViewComponent
{
    private IBookstoreRepository _bookstoreRepository;
    
    //Constructor - a method that is run one time for set up
    public BookTypesViewComponent(IBookstoreRepository temp)
    {
        _bookstoreRepository = temp;
    }
    
    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedCategory = RouteData?.Values["Category"];
        
        var bookCategories = _bookstoreRepository.Books
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x); // order by default alphabetical setting
        
        return View(bookCategories);
    }
}