using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCrudNimapInfoteck.Models;

namespace ProductCrudNimapInfoteck.Controllers
{
    public class ProductController : Controller
    {
        ProductCRUD prodcrud;
        CategoryCRUD catcrud;
        private readonly IConfiguration configuration;
        public ProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
            prodcrud = new ProductCRUD(this.configuration);
            catcrud = new CategoryCRUD(this.configuration);
        }
        // GET: ProductController
        public ActionResult Index(int pg = 1)
        {

            var catList = catcrud.CatList();

            var list = prodcrud.GetAllProduct();
            foreach (Product p in list)
            {
                foreach (Category c in catList)
                {

                    if (p.CategoryId == c.CategoryId)
                    {
                        p.CategoryName = c.CategoryName;

                    }
                }
            }
            const int pagesize = 10;
            if (pg < 1)
            {
                pg = 1;
            }

            int recscount = list.Count();

            var pager = new Pager(recscount, pg, pagesize);

            int recskip = (pg - 1) * pagesize;

            var data = list.Skip(recskip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            return View(data);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var catList = catcrud.CatList();
            ViewBag.CatList = catList;
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                int result = 0;
                result = prodcrud.AddProduct(product);
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var catList = catcrud.CatList();
            ViewBag.CatList = catList;
            var prod = prodcrud.GetProductById(id);
            return View(prod);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod)
        {
            try
            {
                int result = prodcrud.UpdateProduct(prod);
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var prod = prodcrud.GetProductById(id);
            return View(prod);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = prodcrud.DeleteProduct(id);
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
    }
}
