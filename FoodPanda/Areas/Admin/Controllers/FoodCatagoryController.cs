using FoodPanda.DataAccess;
using FoodPanda.DataAccess.Repository.IRepository;
using FoodPanda.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodPanda.Areas.Admin.Controllers;
    [Area("Admin")]

    public class FoodCatagoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodCatagoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<FoodCatagory> objFoodCatagoryList = _unitOfWork.FoodCatagory.GetAll();
            return View(objFoodCatagoryList);
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
        public IActionResult Create(FoodCatagory obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FoodCatagory.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "FoodCatagory added successfully";
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
            var FoodCatagoryFromDbFirst = _unitOfWork.FoodCatagory.GetFirstOrDefault(u => u.FoodCatagoryId == id);
            if (FoodCatagoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(FoodCatagoryFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FoodCatagory obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FoodCatagory.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "FoodCatagory updated successfully";

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
            var FoodCatagoryFromDb = _unitOfWork.FoodCatagory.GetFirstOrDefault(u => u.FoodCatagoryId == id);
            if (FoodCatagoryFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.FoodCatagory.Remove(FoodCatagoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "FoodCatagory deleted successfully";

            return RedirectToAction("Index");
        }

        #endregion
    }

