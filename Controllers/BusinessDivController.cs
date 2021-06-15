using BLMS.v2.Context;
using BLMS.v2.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static BLMS.Helper;

namespace BLMS.v2.Controllers
{
    public class BusinessDivController : Controller
    {
        readonly BLMSDbContext dbContext = new BLMSDbContext();

        // GET: BusinessDivController
        public ActionResult Index()
        {
            List<BusinessDiv> BusinessDivList = dbContext.BusinessDivGetAll().ToList();

            if (TempData["createMessage"] != null)
            {
                ViewBag.Message = TempData["createMessage"].ToString();
            }
            else if(TempData["editMessage"] != null)
            {
                ViewBag.Message = TempData["editMessage"].ToString();
            }
            else if (TempData["deleteMessage"] != null)
            {
                ViewBag.Message = TempData["deleteMessage"].ToString();
            }

            return View(BusinessDivList);
        }

        // GET: BusinessDivController/Create
        [NoDirectAccess]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessDivController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] BusinessDiv businessDiv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string DivName = businessDiv.DivName;

                    BusinessDiv checkbusinessDiv = dbContext.CheckBusinessDivByName(DivName);

                    if (checkbusinessDiv.ExistData == 1)
                    {
                        ViewBag.Message = string.Format("{0} already existed in database!", DivName);
                        return View(businessDiv);
                    }
                    else
                    {
                        dbContext.AddBusinessDiv(businessDiv);
                        TempData["createMessage"] = string.Format("{0} has been successfully created!", DivName);
                        return RedirectToAction("Index");
                    }
                }

                return View(businessDiv);
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessDivController/Edit/5
        [NoDirectAccess]
        public ActionResult Edit(int id)
        {
            BusinessDiv businessDiv = dbContext.GetBusinessDivByID(id);

            if (businessDiv == null)
            {
                return NotFound();
            }

            return View(businessDiv);
        }

        // POST: BusinessDivController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] BusinessDiv businessDiv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string DivName = businessDiv.DivName;
                    
                    BusinessDiv checkbusinessDiv = dbContext.CheckBusinessDivByName(DivName);

                    if (checkbusinessDiv.ExistData == 1)
                    {
                        TempData["editMessage"] = string.Format("{0} already existed in database!", businessDiv.DivName);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        dbContext.EditBusinessDiv(businessDiv);
                        TempData["editMessage"] = string.Format("{0} has been successfully edited!", businessDiv.DivName);
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

        // GET: BusinessDivController/Delete/5
        [NoDirectAccess]
        public ActionResult Delete(int id)
        {
            try
            {
                BusinessDiv businessDiv = dbContext.GetBusinessDivByID(id);
                BusinessDiv CheckLinkedbusinessDiv = dbContext.CheckLinkedBusinessUnitByName(businessDiv.DivName);

                if (CheckLinkedbusinessDiv.LinkedData == 1)
                {
                    TempData["deleteMessage"] = string.Format("{0} has been linked to Business Unit. System cannot delete this business Division!", businessDiv.DivName);
                }
                else
                {
                    dbContext.DeleteBusinessDiv(id);
                    TempData["deleteMessage"] = string.Format("{0} has been successfully deleted!", businessDiv.DivName);
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
