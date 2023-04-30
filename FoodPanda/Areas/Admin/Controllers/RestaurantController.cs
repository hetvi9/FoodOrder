using FoodPanda.DataAccess;
using FoodPanda.DataAccess.Repository.IRepository;
using FoodPanda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace FoodPanda.Areas.Admin.Controllers;
    [Area("Admin")]

    public class RestaurantController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
	private readonly IWebHostEnvironment _hostEnvironment;

	public RestaurantController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
		_hostEnvironment = hostEnvironment;

	}
	public IActionResult Index()
        {
            IEnumerable<Restaurant> objRestaurantList = _unitOfWork.Restaurant.GetAll();
            return View(objRestaurantList);
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
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            /**/ /*var RestaurantFromDb = _db.Restaurant.Find(id);*/
            var RestaurantFromDbFirst = _unitOfWork.Restaurant.GetFirstOrDefault(u => u.RestaurantId == id);
            if (RestaurantFromDbFirst == null)
            {
                return NotFound();
            }
            return View(RestaurantFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Restaurant obj)
        {
		

		if (ModelState.IsValid)
            {
			

			_unitOfWork.Restaurant.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Restaurant updated successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #endregion
        #region Delete
        //GET
        /*  public IActionResult Delete(int? id)
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
          }*/
        //POST
        /* [HttpPost,ActionName("Delete")]
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
 */
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

        #endregion
    }

