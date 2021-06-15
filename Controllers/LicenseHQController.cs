using BLMS.v2.Context;
using BLMS.v2.Models.License;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BLMS.Helper;

namespace BLMS.v2.Controllers
{
    public class LicenseHQController : Controller
    {
        readonly LicenseDbContext licenseHQDbContext = new LicenseDbContext();
        readonly ddlDbContext dbDDLContext = new ddlDbContext();

        // GET: LicenseHQController
        public ActionResult Index()
        {
            List<LicenseHQ> licenseHQList = licenseHQDbContext.LicenseHQGetAll().ToList();

            return View(licenseHQList);
        }

        // GET: LicenseHQController/Details/5
        [NoDirectAccess]
        public ActionResult Details(int id)
        {
            LicenseHQ licenseHQ = licenseHQDbContext.GetLicenseHQByID(id);

            if (licenseHQ == null)
            {
                return NotFound();
            }

            return View(licenseHQ);
        }

        // GET: LicenseHQController/Create
        public ActionResult Create()
        {
            //ddlCategory
            List<LicenseHQ> categoryLicenseHQList = dbDDLContext.ddlCategoryLicenseHQ().ToList();
            categoryLicenseHQList.Insert(0, new LicenseHQ { CategoryID = 0, CategoryName = "Please Select Type of License" });
            ViewBag.ListofCategory = categoryLicenseHQList;

            //ddlBusinessDiv
            List<LicenseHQ> businessDivLicenseHQList = dbDDLContext.ddlBusinessDivLicenseHQ().ToList();
            businessDivLicenseHQList.Insert(0, new LicenseHQ { DivID = 0, DivName = "Please Select Business Division" });
            ViewBag.ListofBusinessDiv = businessDivLicenseHQList;

            //ddlBusinessUnit
            List<LicenseHQ> businessUnitLicenseHQList = dbDDLContext.ddlBusinessUnitLicenseHQ().ToList();
            businessUnitLicenseHQList.Insert(0, new LicenseHQ { UnitID = 0, UnitName = "Please Select Business Unit" });
            ViewBag.ListofBusinessUnit = businessUnitLicenseHQList;

            //ddlPIC2
            List<LicenseHQ> PIC2LicenseHQList = dbDDLContext.ddlPIC2LicenseHQ().ToList();
            PIC2LicenseHQList.Insert(0, new LicenseHQ { PIC2StaffNo = "-", PIC2Name = "Please Select PIC 2 Name" });
            ViewBag.ListofPIC2 = PIC2LicenseHQList;

            //ddlPIC3
            List<LicenseHQ> PIC3LicenseHQList = dbDDLContext.ddlPIC3LicenseHQ().ToList();
            PIC3LicenseHQList.Insert(0, new LicenseHQ { PIC3StaffNo = "-", PIC3Name = "Please Select PIC 3 Name" });
            ViewBag.ListofPIC3 = PIC3LicenseHQList;

            return View();
        }

        // POST: LicenseHQController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] LicenseHQ licenseHQ)
        {
            try
            {
                if (licenseHQ.CategoryID == 0)
                {
                    ModelState.AddModelError("", "Please Select Type of License");
                }
                else if (licenseHQ.DivID == 0)
                {
                    ModelState.AddModelError("", "Please Select Business Division");
                }
                else if (licenseHQ.UnitID == 0)
                {
                    ModelState.AddModelError("", "Please Select Business Unit");
                }
                else if (ModelState.IsValid)
                {
                    if (String.IsNullOrEmpty(licenseHQ.Remarks))
                    {
                        licenseHQ.Remarks = "-";
                    }

                    licenseHQDbContext.RequestLicenseHQ(licenseHQ);

                    //ddlCategory
                    List<LicenseHQ> categoryLicenseHQList = dbDDLContext.ddlCategoryLicenseHQ().ToList();
                    categoryLicenseHQList.Insert(0, new LicenseHQ { CategoryID = 0, CategoryName = "Please Select Type of License" });
                    ViewBag.ListofCategory = categoryLicenseHQList;

                    //ddlBusinessDiv
                    List<LicenseHQ> businessDivLicenseHQList = dbDDLContext.ddlBusinessDivLicenseHQ().ToList();
                    businessDivLicenseHQList.Insert(0, new LicenseHQ { DivID = 0, DivName = "Please Select Business Division" });
                    ViewBag.ListofBusinessDiv = businessDivLicenseHQList;

                    //ddlBusinessUnit
                    List<LicenseHQ> businessUnitLicenseHQList = dbDDLContext.ddlBusinessUnitLicenseHQ().ToList();
                    businessUnitLicenseHQList.Insert(0, new LicenseHQ { UnitID = 0, UnitName = "Please Select Business Unit" });
                    ViewBag.ListofBusinessUnit = businessUnitLicenseHQList;

                    //ddlPIC2
                    List<LicenseHQ> PIC2LicenseHQList = dbDDLContext.ddlPIC2LicenseHQ().ToList();
                    PIC2LicenseHQList.Insert(0, new LicenseHQ { PIC2StaffNo = "-", PIC2Name = "Please Select PIC 2 Name" });
                    ViewBag.ListofPIC2 = PIC2LicenseHQList;

                    //ddlPIC3
                    List<LicenseHQ> PIC3LicenseHQList = dbDDLContext.ddlPIC3LicenseHQ().ToList();
                    PIC3LicenseHQList.Insert(0, new LicenseHQ { PIC3StaffNo = "-", PIC3Name = "Please Select PIC 3 Name" });
                    ViewBag.ListofPIC3 = PIC3LicenseHQList;

                    return RedirectToAction("Index");
                }

                return View(licenseHQ);
            }
            catch
            {
                return View();
            }
        }
    }
}
