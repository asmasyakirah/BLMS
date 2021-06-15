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
    public class PICController : Controller
    {
        readonly BLMSDbContext dbContext = new BLMSDbContext();
        readonly ddlDbContext dbDDLContext = new ddlDbContext();

        // GET: PICController
        public ActionResult Index()
        {
            List<PIC> PICList = dbContext.PICGetAll().ToList();

            return View(PICList);
        }

        // GET: PICController/Details/5
        public ActionResult Details(int id)
        {
            PIC pic = dbContext.GetPICByID(id);

            if (pic == null)
            {
                return NotFound();
            }

            return View(pic);
        }

        // GET: PICController/Create
        [NoDirectAccess]
        public ActionResult Create()
        {
            //ddlStaffName
            List<PIC> staffNamePICList = dbDDLContext.ddlStaffNamePIC().ToList();
            staffNamePICList.Insert(0, new PIC { PICStaffNo = "-", PICName = "Please Select Staff Name" });
            ViewBag.ListofStaffName = staffNamePICList;

            //ddlBusinessDiv
            List<PIC> businessDivPICList = dbDDLContext.ddlBusinessDivPIC().ToList();
            businessDivPICList.Insert(0, new PIC { DivID = 0, DivName = "Please Select Business Division" });
            ViewBag.ListofBusinessDiv = businessDivPICList;

            //ddlBusinessUnit
            List<PIC> businessUnitPICList = dbDDLContext.ddlBusinessUnitPIC().ToList();
            businessUnitPICList.Insert(0, new PIC { UnitID = 0, UnitName = "Please Select Business Unit" });
            ViewBag.ListofBusinessUnit = businessUnitPICList;

            //ddlUnitType
            List<PIC> userTypePICList = dbDDLContext.ddlUserTypePIC().ToList();
            userTypePICList.Insert(0, new PIC { UserTypeID = 0, UserType = "Please Select Type of User" });
            ViewBag.ListofUserType = userTypePICList;

            return View();
        }

        // POST: PICController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] PIC pic)
        {
            try
            {
                //Validate All
                if (pic.PICStaffNo == "-" && pic.DivID == 0 && pic.UnitID == 0 && pic.UserTypeID == 0)
                {
                    ModelState.AddModelError("", "Please Select Staff Name");
                    ModelState.AddModelError("", "Please Select Business Division");
                    ModelState.AddModelError("", "Please Select Business Unit");
                    ModelState.AddModelError("", "Please Select Type of User");
                }
                //Validate Staff Name
                else if (pic.PICStaffNo == "-")
                {
                    ModelState.AddModelError("", "Please Select Staff Name");
                }
                //Validate Business Div
                else if (pic.DivID == 0)
                {
                    ModelState.AddModelError("", "Please Select Business Division");
                }
                //Validate Business Unit
                else if (pic.UnitID == 0)
                {
                    ModelState.AddModelError("", "Please Select Business Unit");
                }
                //Validate User Type
                else if (pic.UserTypeID == 0)
                {
                    ModelState.AddModelError("", "Please Select Type of User");
                }

                if (ModelState.IsValid)
                {
                    dbContext.AddPIC(pic);
                    return RedirectToAction("Index");
                }

                //ddlStaffName
                List<PIC> staffNamePICList = dbDDLContext.ddlStaffNamePIC().ToList();
                staffNamePICList.Insert(0, new PIC { PICStaffNo = "-", PICName = "Please Select Staff Name" });
                ViewBag.ListofStaffName = staffNamePICList;

                //ddlBusinessDiv
                List<PIC> businessDivPICList = dbDDLContext.ddlBusinessDivPIC().ToList();
                businessDivPICList.Insert(0, new PIC { DivID = 0, DivName = "Please Select Business Division" });
                ViewBag.ListofBusinessDiv = businessDivPICList;

                //ddlBusinessUnit
                List<PIC> businessUnitPICList = dbDDLContext.ddlBusinessUnitPIC().ToList();
                businessUnitPICList.Insert(0, new PIC { UnitID = 0, UnitName = "Please Select Business Unit" });
                ViewBag.ListofBusinessUnit = businessUnitPICList;

                //ddlUnitType
                List<PIC> userTypePICList = dbDDLContext.ddlUserTypePIC().ToList();
                userTypePICList.Insert(0, new PIC { UserTypeID = 0, UserType = "Please Select Type of User" });
                ViewBag.ListofUserType = userTypePICList;

                return View(pic);
            }
            catch
            {
                return View();
            }
        }

        // GET: PICController/Edit/5
        [NoDirectAccess]
        public ActionResult Edit(int id)
        {
            PIC pic = dbContext.GetPICByID(id);

            //ddlStaffName
            List<PIC> staffNamePICList = dbDDLContext.ddlStaffNamePIC().ToList();
            staffNamePICList.Insert(0, new PIC { PICStaffNo = "-", PICName = "Please Select Staff Name" });
            ViewBag.ListofStaffName = staffNamePICList;

            //ddlBusinessDiv
            List<PIC> businessDivPICList = dbDDLContext.ddlBusinessDivPIC().ToList();
            businessDivPICList.Insert(0, new PIC { DivID = 0, DivName = "Please Select Business Division" });
            ViewBag.ListofBusinessDiv = businessDivPICList;

            //ddlBusinessUnit
            List<PIC> businessUnitPICList = dbDDLContext.ddlBusinessUnitPIC().ToList();
            businessUnitPICList.Insert(0, new PIC { UnitID = 0, UnitName = "Please Select Business Unit" });
            ViewBag.ListofBusinessUnit = businessUnitPICList;

            //ddlUnitType
            List<PIC> userTypePICList = dbDDLContext.ddlUserTypePIC().ToList();
            userTypePICList.Insert(0, new PIC { UserTypeID = 0, UserType = "Please Select Type of User" });
            ViewBag.ListofUserType = userTypePICList;

            if (pic == null)
            {
                return NotFound();
            }

            return View(pic);
        }

        // POST: PICController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] PIC pic)
        {
            try
            {
                //Validate All
                if (pic.PICStaffNo == "-" && pic.DivID == 0 && pic.UnitID == 0 && pic.UserTypeID == 0)
                {
                    ModelState.AddModelError("", "Please Select Staff Name");
                    ModelState.AddModelError("", "Please Select Business Division");
                    ModelState.AddModelError("", "Please Select Business Unit");
                    ModelState.AddModelError("", "Please Select Type of User");
                }
                //Validate Staff Name
                else if (pic.PICStaffNo == "-")
                {
                    ModelState.AddModelError("", "Please Select Staff Name");
                }
                //Validate Business Div
                else if (pic.DivID == 0)
                {
                    ModelState.AddModelError("", "Please Select Business Division");
                }
                //Validate Business Unit
                else if (pic.UnitID == 0)
                {
                    ModelState.AddModelError("", "Please Select Business Unit");
                }
                //Validate User Type
                else if (pic.UserTypeID == 0)
                {
                    ModelState.AddModelError("", "Please Select Type of User");
                }

                if (ModelState.IsValid)
                {
                    dbContext.EditPIC(pic);
                    return RedirectToAction("Index");
                }

                //ddlStaffName
                List<PIC> staffNamePICList = dbDDLContext.ddlStaffNamePIC().ToList();
                staffNamePICList.Insert(0, new PIC { PICStaffNo = "-", PICName = "Please Select Staff Name" });
                ViewBag.ListofStaffName = staffNamePICList;

                //ddlBusinessDiv
                List<PIC> businessDivPICList = dbDDLContext.ddlBusinessDivPIC().ToList();
                businessDivPICList.Insert(0, new PIC { DivID = 0, DivName = "Please Select Business Division" });
                ViewBag.ListofBusinessDiv = businessDivPICList;

                //ddlBusinessUnit
                List<PIC> businessUnitPICList = dbDDLContext.ddlBusinessUnitPIC().ToList();
                businessUnitPICList.Insert(0, new PIC { UnitID = 0, UnitName = "Please Select Business Unit" });
                ViewBag.ListofBusinessUnit = businessUnitPICList;

                //ddlUnitType
                List<PIC> userTypePICList = dbDDLContext.ddlUserTypePIC().ToList();
                userTypePICList.Insert(0, new PIC { UserTypeID = 0, UserType = "Please Select Type of User" });
                ViewBag.ListofUserType = userTypePICList;

                return View(dbContext);
            }
            catch
            {
                return View();
            }
        }

        // GET: PICController/Delete/5
        [NoDirectAccess]
        public ActionResult Delete(int id)
        {
            PIC pic = dbContext.GetPICByID(id);

            if (pic == null)
            {
                return NotFound();
            }

            return View(pic);
        }

        // POST: PICController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                dbContext.DeletePIC(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
