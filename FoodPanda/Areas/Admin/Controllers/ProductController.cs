using FoodPanda.DataAccess;
using FoodPanda.DataAccess.Repository.IRepository;
using FoodPanda.Models;
using FoodPanda.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace FoodPanda.Areas.Admin.Controllers;
[Area("Admin")]

public class ProductController : Controller
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IWebHostEnvironment _hostEnvironment ;
	public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
	{
		_unitOfWork = unitOfWork;
		_hostEnvironment = hostEnvironment;
	}
	public IActionResult Index()
	{
		return View();
	}
	#region Create
	//GET
	public IActionResult Create()
	{
		return View();
	}
	//POST
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(Restaurant obj)
	{
		if (ModelState.IsValid)
		{
			_unitOfWork.Restaurant.Add(obj);
			_unitOfWork.Save();
			TempData["success"] = "Restaurant added successfully";
			return RedirectToAction("Index");
		}
		return View(obj);
	}
	#endregion
	#region Edit
	//GET
	public IActionResult Upsert(int? id)
	{

		ProductVM productVM = new()
		{
			Product = new(),
			RestaurantList = _unitOfWork.Restaurant.GetAll().Select(i => new SelectListItem
			{
				Text = i.RestaurantName,
				Value = i.RestaurantId.ToString()

			}),
			FoodCatagoryList = _unitOfWork.FoodCatagory.GetAll().Select(i => new SelectListItem
			{
				Text = i.FoodCatagoryType,
				Value = i.FoodCatagoryId.ToString()

			}),
		};
		if (id == null || id == 0)
		{
			
			return View(productVM);


		}
		else
		{
			productVM.Product=_unitOfWork.Product.GetFirstOrDefault(u=>u.Id==id);
		return View(productVM);
		}


	}
	//POST
	[HttpPost]
	[ValidateAntiForgeryToken]
	/*public IActionResult Upsert(ProductVM obj, IFormFile? file)
	{
		if (ModelState.IsValid)
		{
			string wwwRootPath = _hostEnvironment.WebRootPath;
			if (file != null)
			{
				string fileName = Guid.NewGuid().ToString();
				var uploads = Path.Combine(wwwRootPath, @"images\products");
				var extension = Path.GetExtension(file.FileName);
                if (obj.Product.ImageUrl != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
				{
					file.CopyTo(fileStreams);
				}
				obj.Product.ImageUrl = @"\images\products\" + fileName + extension;
			}
			if(obj.Product.Id==0)
			{
				_unitOfWork.Product.Add(obj.Product);
			}
			else
			{
				_unitOfWork.Product.Update(obj.Product);
			}
			_unitOfWork.Save();
			TempData["success"] = "Product created successfully";
				return RedirectToAction("Index");
		}
		return View(obj);
	}
*/

	public IActionResult Upsert(ProductVM obj, IFormFile? file)
	{

		if (ModelState.IsValid)
		{
			string wwwRootPath = _hostEnvironment.WebRootPath;
			if (file != null)
			{
				string fileName = Guid.NewGuid().ToString();
				var uploads = Path.Combine(wwwRootPath, @"images\products");
				var extension = Path.GetExtension(file.FileName);

					if (obj.Product.ImageUrl != null)
				{
					var oldImagePath = Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));
					if (System.IO.File.Exists(oldImagePath))
					{
						System.IO.File.Delete(oldImagePath);
					}
				}

				using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
				{
					file.CopyTo(fileStreams);
				}
				obj.Product.ImageUrl = @"\images\products\" + fileName + extension;

			}
			if (obj.Product.Id == 0)
			{
				_unitOfWork.Product.Add(obj.Product);
			}
			else
			{
				_unitOfWork.Product.Update(obj.Product);
			}
			_unitOfWork.Save();
			TempData["success"] = "Product created successfully";
			return RedirectToAction("Index");
		}
		return View(obj);
	}


	#endregion
	/*#region Delete
	//GET
	*//*  public IActionResult Delete(int? id)
	  {
		  if (id == null || id == 0)
		  {
			  return NotFound();

		  }
		  var RestaurantFromDb = _db.Restaurant.Find(id);
		  if (RestaurantFromDb == null)
		  {
			  return NotFound();
		  }
		  return View(RestaurantFromDb);
	  }*//*
	//POST
	*//* [HttpPost,ActionName("Delete")]
	 [ValidateAntiForgeryToken]
	 public IActionResult DeletePOST(int? id)
	 {

		 var obj = _db.Restaurant.Find(id);
		 if (obj == null)
		 {
			 return NotFound();  
		 }

			 _db.Restaurant.Remove(obj);
			 _db.SaveChanges();
			 return RedirectToAction("Index");

	 }
*//*
	public IActionResult Delete(int? id)
	{
		if (id == null || id == 0)
		{
			return NotFound();

		}
		var RestaurantFromDb = _unitOfWork.Restaurant.GetFirstOrDefault(u => u.RestaurantId == id);
		if (RestaurantFromDb == null)
		{
			return NotFound();
		}
		_unitOfWork.Restaurant.Remove(RestaurantFromDb);
		_unitOfWork.Save();
		TempData["success"] = "Restaurant deleted successfully";

		return RedirectToAction("Index");
	}

	#endregion*/
	#region API CALLS
	[HttpGet]
	public IActionResult GetAll()
	{
		var  productList = _unitOfWork.Product.GetAll(includeProperties: "Restaurant,FoodCatagory");
		return Json(new { data = productList });
	}

	#endregion
	#region delete
	//POST
	[HttpDelete]
	public IActionResult Delete(int? id)
	{
		var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
		if (obj == null)
		{
			return Json(new { success = false, message = "Error while deleting" });
		}

		var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
		if (System.IO.File.Exists(oldImagePath))
		{
			System.IO.File.Delete(oldImagePath);
		}

		_unitOfWork.Product.Remove(obj);
		_unitOfWork.Save();
		return Json(new { success = true, message = "Delete Successful" });

	}
#endregion
}

