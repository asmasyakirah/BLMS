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
    public class BusinessUnitController : Controller
    {
        readonly BLMSDbContext dbContext = new BLMSDbContext();
        readonly ddlDbContext dbDDLContext = new ddlDbContext();

        // GET: BusinessUnitController
        public ActionResult Index()
        {
            List<BusinessUnit> BusinessUnitList = dbContext.BusinessUnitGetAll().ToList();

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

            return View(BusinessUnitList);
        }

        // GET: BusinessUnitController/Details/5
        public ActionResult Details(int id)
        {
            BusinessUnit businessUnit = dbContext.GetBusinessUnitByID(id);

            if (businessUnit == null)
            {
                return NotFound();
            }

            return View(businessUnit);
        }

        // GET: BusinessUnitController/Create
        [NoDirectAccess]
        public ActionResult Create()
        {
            List<BusinessUnit> businessDivList = dbDDLContext.ddlBusinessDiv().ToList();
            businessDivList.Insert(0, new BusinessUnit { DivID = 0, DivName = "Please Select Business Division" });
            ViewBag.ListofBusinessDiv = businessDivList;

            return View();
        }

        // POST: BusinessUnitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] BusinessUnit businessUnit)
        {
            try
            {
                List<BusinessUnit> businessDivList = dbDDLContext.ddlBusinessDiv().ToList();

                //Validate Business Division
                if (businessUnit.DivID == 0)
                {
                    ModelState.AddModelError("", "Please Select Business Division");
                }

                if (ModelState.IsValid)
                {
                    string UnitName = businessUnit.UnitName;

                    BusinessUnit checkbusinessUnit = dbContext.CheckBusinessUnitByName(UnitName);

                    if (checkbusinessUnit.ExistData == 1)
                    {
                        ViewBag.Message = string.Format("{0} already existed in database!", UnitName);

                        //Set Data Back After Postback
                        
                        businessDivList.Insert(0, new BusinessUnit { DivID = 0, DivName = "Please Select Business Division" });
                        ViewBag.ListofBusinessDiv = businessDivList;

                        return View(businessUnit);
                    }
                    else
                    {
                        dbContext.AddBusinessUnit(businessUnit);
                        TempData["createMessage"] = string.Format("{0} has been successfully created!", UnitName);
                        return RedirectToAction("Index");
                    }
                }

                //Set Data Back After Postback
                businessDivList.Insert(0, new BusinessUnit { DivID = 0, DivName = "Please Select Business Division" });
                ViewBag.ListofBusinessDiv = businessDivList;

                return View(businessUnit);
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessUnitController/Edit/5
        [NoDirectAccess]
        public ActionResult Edit(int id)
        {
            BusinessUnit businessUnit = dbContext.GetBusinessUnitByID(id);

            List<BusinessUnit> businessDivList = dbDDLContext.ddlBusinessDiv().ToList();
            businessDivList.Insert(0, new BusinessUnit { DivID = 0, DivName = "Please Select Business Division" });
            ViewBag.ListofBusinessDiv = businessDivList;

            if (businessUnit == null)
            {
                return NotFound();
            }

            return View(businessUnit);
        }

        // POST: BusinessUnitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] BusinessUnit businessUnit)
        {
            try
            {
                List<BusinessUnit> businessDivList = dbDDLContext.ddlBusinessDiv().ToList();

                //Validate Business Division
                if (businessUnit.DivID == 0)
                {
                    ModelState.AddModelError("", "Please Select Business Division");
                }
                
                if (ModelState.IsValid)
                {
                    string UnitName = businessUnit.UnitName;

                    BusinessUnit checkbusinessUnit = dbContext.CheckBusinessUnitByName(UnitName);

                    if (checkbusinessUnit.ExistData == 1)
                    {
                        TempData["editMessage"] = string.Format("{0} already existed in database!", UnitName);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        dbContext.EditBusinessUnit(businessUnit);
                        TempData["editMessage"] = string.Format("{0} has been successfully edited!", businessUnit.UnitName);
                        return RedirectToAction("Index");
                    }
                }

                //Set Data Back After Postback
                businessDivList.Insert(0, new BusinessUnit { DivID = 0, DivName = "Please Select Business Division" });
                ViewBag.ListofBusinessDiv = businessDivList;

                return View(dbContext);
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessUnitController/Delete/5
        [NoDirectAccess]
        public ActionResult Delete(int id)
        {
            try
            {
                BusinessUnit businessUnit = dbContext.GetBusinessUnitByID(id);

                dbContext.DeleteBusinessUnit(id);
                TempData["deleteMessage"] = string.Format("{0} has been successfully deleted!", businessUnit.UnitName);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
