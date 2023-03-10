using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProductCrudNimapInfoteck.Models;

namespace ProductCrudNimapInfoteck.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration configuration;
        CategoryCRUD crud;
        public CategoryController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new CategoryCRUD(this.configuration);


        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var list=crud.CatList();
            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cat)
        {
            try
            {
                int result = 0;
                result = crud.AddCat(cat);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
                
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var cat = crud.GetCatById(id);
            return View(cat);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cat)
        {
            try
            {
                int result = crud.UpdateCat(cat);
                if(result==1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = crud.GetCatById(id);
            return View(cat);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteCat(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
