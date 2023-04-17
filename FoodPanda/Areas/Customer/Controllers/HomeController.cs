using FoodPanda.DataAccess.Repository.IRepository;
using FoodPanda.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodPanda.Areas.Customer.Controllers;
[Area("Customer")]


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
		IEnumerable<Product> ProductList = _unitOfWork.Product.GetAll(includeProperties: "Restaurant,FoodCatagory");
       
        return View(ProductList);
    }
    public IActionResult Details(int id)
    {
        ShoppingCart cartObj = new()
        {
            Count = 1,
            Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id, includeProperties: "Restaurant,FoodCatagory"),
        };
        return View(cartObj);
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
}