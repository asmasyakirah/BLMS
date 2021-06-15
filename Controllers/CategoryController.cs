using BLMS.v2.Context;
using BLMS.v2.Models.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BLMS.Helper;

namespace BLMS.v2.Controllers
{
    public class CategoryController : Controller
    {
        readonly BLMSDbContext dbContext = new BLMSDbContext();

        // GET: CategoryController
        public ActionResult Index()
        {
            List<Category> CategoryList = dbContext.CategoryGetAll().ToList();

            if (TempData["createMessage"] != null)
            {
                ViewBag.Message = TempData["createMessage"].ToString();
            }
            else if (TempData["editMessage"] != null)
            {
                ViewBag.Message = TempData["editMessage"].ToString();
            }
            else if (TempData["deleteMessage"] != null)
            {
                ViewBag.Message = TempData["deleteMessage"].ToString();
            }

            return View(CategoryList);
        }

        // GET: CategoryController/Create
        [NoDirectAccess]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string CategoryName = category.CategoryName;

                    Category checkCategory = dbContext.CheckCategoryByName(CategoryName);

                    if (checkCategory.ExistData == 1)
                    {
                        ViewBag.Message = string.Format("{0} already existed in database!", CategoryName);
                        return View(category);
                    }
                    else
                    {
                        dbContext.AddCategory(category);
                        TempData["createMessage"] = string.Format("{0} has been successfully created!", CategoryName);
                        return RedirectToAction("Index");
                    }
                }

                return View(category);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        [NoDirectAccess]
        public ActionResult Edit(int id)
        {
            Category category = dbContext.GetCategoryByID(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string CategoryName = category.CategoryName;

                    Category checkCategory = dbContext.CheckCategoryByName(CategoryName);

                    if (checkCategory.ExistData == 1)
                    {
                        TempData["editMessage"] = string.Format("{0} already existed in database!", CategoryName);
                        return View(category);
                    }
                    else
                    {
                        dbContext.EditCategory(category);
                        TempData["editMessage"] = string.Format("{0} has been successfully edited!", category.CategoryName);
                        return RedirectToAction("Index");
                    }
                }

                return View(dbContext);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        [NoDirectAccess]
        public ActionResult Delete(int id)
        {
            try
            {
                Category category = dbContext.GetCategoryByID(id);

                dbContext.DeleteCategory(id);
                TempData["deleteMessage"] = string.Format("{0} has been successfully deleted!", category.CategoryName);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
