using BLMS.v2.Context;
using BLMS.v2.Models.License;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static BLMS.Helper;

namespace BLMS.v2.Controllers
{
    public class LicenseSiteController : Controller
    {
        readonly LicenseDbContext licenseSiteDbContext = new LicenseDbContext();
        readonly ddlDbContext dbDDLContext = new ddlDbContext();

        // GET: LicenseSiteController
        public ActionResult Index()
        {
            List<LicenseSite> licenseSiteList = licenseSiteDbContext.LicenseSiteGetAll().ToList();

            return View(licenseSiteList);
        }

        // GET: LicenseSiteController/Details/5
        [NoDirectAccess]
        public ActionResult Details(int id)
        {
            LicenseSite licenseSite = licenseSiteDbContext.GetLicenseSiteByID(id);

            if (licenseSite == null)
            {
                return NotFound();
            }

            return View(licenseSite);
        }

        #region Register
        // GET: LicenseSiteController/Register
        public ActionResult Register()
        {
            //ddlCategory
            List<LicenseSite> categoryLicenseSiteList = dbDDLContext.ddlCategoryLicenseSite().ToList();
            categoryLicenseSiteList.Insert(0, new LicenseSite { CategoryID = 0, CategoryName = "Please Select Type of License" });
            ViewBag.ListofCategory = categoryLicenseSiteList;

            //ddlBusinessDiv
            List<LicenseSite> businessDivLicenseSiteList = dbDDLContext.ddlBusinessDivLicenseSite().ToList();
            businessDivLicenseSiteList.Insert(0, new LicenseSite { DivID = 0, DivName = "Please Select Business Division" });
            ViewBag.ListofBusinessDiv = businessDivLicenseSiteList;

            //ddlBusinessUnit
            List<LicenseSite> businessUnitLicenseSiteList = dbDDLContext.ddlBusinessUnitLicenseSite().ToList();
            businessUnitLicenseSiteList.Insert(0, new LicenseSite { UnitID = 0, UnitName = "Please Select Business Unit" });
            ViewBag.ListofBusinessUnit = businessUnitLicenseSiteList;

            //ddlPIC2
            List<LicenseSite> PIC2LicenseSiteList = dbDDLContext.ddlPIC2LicenseSite().ToList();
            PIC2LicenseSiteList.Insert(0, new LicenseSite { PIC2StaffNo = "-", PIC2Name = "Please Select PIC 2 Name" });
            ViewBag.ListofPIC2 = PIC2LicenseSiteList;

            //ddlPIC3
            List<LicenseSite> PIC3LicenseSiteList = dbDDLContext.ddlPIC3LicenseSite().ToList();
            PIC3LicenseSiteList.Insert(0, new LicenseSite { PIC3StaffNo = "-", PIC3Name = "Please Select PIC 3 Name" });
            ViewBag.ListofPIC3 = PIC3LicenseSiteList;

            return View();
        }

        // POST: LicenseSiteController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind] LicenseSite licenseSite, List<IFormFile> LicenseFile)
        {
            try
            {
                if (licenseSite.CategoryID == 0)
                {
                    ModelState.AddModelError("", "Please Select Type of License");
                }
                else if (licenseSite.DivID == 0)
                {
                    ModelState.AddModelError("", "Please Select Business Division");
                }
                else if (licenseSite.UnitID == 0)
                {
                    ModelState.AddModelError("", "Please Select Business Unit");
                }
                else if (ModelState.IsValid)
                {
                    if (String.IsNullOrEmpty(licenseSite.SerialNo))
                    {
                        licenseSite.SerialNo = "-";
                    }

                    if (String.IsNullOrEmpty(licenseSite.IssuedDT))
                    {
                        licenseSite.IssuedDT = "-";
                    }

                    if (String.IsNullOrEmpty(licenseSite.ExpiredDT))
                    {
                        licenseSite.ExpiredDT = "-";
                    }

                    if (String.IsNullOrEmpty(licenseSite.Remarks))
                    {
                        licenseSite.Remarks = "-";
                    }

                    foreach (var licenseFile in LicenseFile)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(licenseFile.FileName);
                        var extension = Path.GetExtension(licenseFile.FileName);

                        licenseSite.FileType = licenseFile.ContentType;
                        licenseSite.Extension = extension;
                        licenseSite.LicenseFileName = fileName;

                        using (var dataStream = new MemoryStream())
                        {
                            licenseFile.CopyToAsync(dataStream);
                            licenseSite.Data = dataStream.ToArray();
                        }
                    }

                    if (LicenseFile.Count == 0)
                    {
                        licenseSite.LicenseFileName = "-";
                    }

                    licenseSiteDbContext.RegisterLicenseSite(licenseSite);

                    //ddlCategory
                    List<LicenseSite> categoryLicenseSiteList = dbDDLContext.ddlCategoryLicenseSite().ToList();
                    categoryLicenseSiteList.Insert(0, new LicenseSite { CategoryID = 0, CategoryName = "Please Select Type of License" });
                    ViewBag.ListofCategory = categoryLicenseSiteList;

                    //ddlBusinessDiv
                    List<LicenseSite> businessDivLicenseSiteList = dbDDLContext.ddlBusinessDivLicenseSite().ToList();
                    businessDivLicenseSiteList.Insert(0, new LicenseSite { DivID = 0, DivName = "Please Select Business Division" });
                    ViewBag.ListofBusinessDiv = businessDivLicenseSiteList;

                    //ddlBusinessUnit
                    List<LicenseSite> businessUnitLicenseSiteList = dbDDLContext.ddlBusinessUnitLicenseSite().ToList();
                    businessUnitLicenseSiteList.Insert(0, new LicenseSite { UnitID = 0, UnitName = "Please Select Business Unit" });
                    ViewBag.ListofBusinessUnit = businessUnitLicenseSiteList;

                    //ddlPIC2
                    List<LicenseSite> PIC2LicenseSiteList = dbDDLContext.ddlPIC2LicenseSite().ToList();
                    PIC2LicenseSiteList.Insert(0, new LicenseSite { PIC2StaffNo = "-", PIC2Name = "Please Select PIC 2 Name" });
                    ViewBag.ListofPIC2 = PIC2LicenseSiteList;

                    //ddlPIC3
                    List<LicenseSite> PIC3LicenseSiteList = dbDDLContext.ddlPIC3LicenseSite().ToList();
                    PIC3LicenseSiteList.Insert(0, new LicenseSite { PIC3StaffNo = "-", PIC3Name = "Please Select PIC 3 Name" });
                    ViewBag.ListofPIC3 = PIC3LicenseSiteList;

                    return RedirectToAction("Index");
                }

                return View(licenseSite);
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Renewal
        // GET: CategoryController/Renewal/5
        [NoDirectAccess]
        public ActionResult Renewal(int id)
        {
            LicenseSite licenseSite = licenseSiteDbContext.GetLicenseSiteByID(id);

            //ddlCategory
            List<LicenseSite> categoryLicenseSiteList = dbDDLContext.ddlCategoryLicenseSite().ToList();
            categoryLicenseSiteList.Insert(0, new LicenseSite { CategoryID = 0, CategoryName = "Please Select Type of License" });
            ViewBag.ListofCategory = categoryLicenseSiteList;

            //ddlBusinessDiv
            List<LicenseSite> businessDivLicenseSiteList = dbDDLContext.ddlBusinessDivLicenseSite().ToList();
            businessDivLicenseSiteList.Insert(0, new LicenseSite { DivID = 0, DivName = "Please Select Business Division" });
            ViewBag.ListofBusinessDiv = businessDivLicenseSiteList;

            //ddlBusinessUnit
            List<LicenseSite> businessUnitLicenseSiteList = dbDDLContext.ddlBusinessUnitLicenseSite().ToList();
            businessUnitLicenseSiteList.Insert(0, new LicenseSite { UnitID = 0, UnitName = "Please Select Business Unit" });
            ViewBag.ListofBusinessUnit = businessUnitLicenseSiteList;

            //ddlPIC2
            List<LicenseSite> PIC2LicenseSiteList = dbDDLContext.ddlPIC2LicenseSite().ToList();
            PIC2LicenseSiteList.Insert(0, new LicenseSite { PIC2StaffNo = "-", PIC2Name = "Please Select PIC 2 Name" });
            ViewBag.ListofPIC2 = PIC2LicenseSiteList;

            //ddlPIC3
            List<LicenseSite> PIC3LicenseSiteList = dbDDLContext.ddlPIC3LicenseSite().ToList();
            PIC3LicenseSiteList.Insert(0, new LicenseSite { PIC3StaffNo = "-", PIC3Name = "Please Select PIC 3 Name" });
            ViewBag.ListofPIC3 = PIC3LicenseSiteList;

            if (licenseSite == null)
            {
                return NotFound();
            }

            return View(licenseSite);
        }

        // POST: PICController/Renewal/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Renewal(int id, [Bind] LicenseSite licenseSite, List<IFormFile> RenewalLicenseFile)
        {
            try
            {
                if (licenseSite.CategoryID == 0)
                {
                    ModelState.AddModelError("", "Please Select Type of License");
                }
                else if (licenseSite.DivID == 0)
                {
                    ModelState.AddModelError("", "Please Select Business Division");
                }
                else if (licenseSite.UnitID == 0)
                {
                    ModelState.AddModelError("", "Please Select Business Unit");
                }
                else if (ModelState.IsValid)
                {
                    if (String.IsNullOrEmpty(licenseSite.RenewalSerialNo))
                    {
                        licenseSite.RenewalSerialNo = "-";
                    }

                    if (String.IsNullOrEmpty(licenseSite.RenewalIssuedDT))
                    {
                        licenseSite.RenewalIssuedDT = "-";
                    }

                    if (String.IsNullOrEmpty(licenseSite.RenewalExpiredDT))
                    {
                        licenseSite.RenewalExpiredDT = "-";
                    }

                    if (String.IsNullOrEmpty(licenseSite.Remarks))
                    {
                        licenseSite.Remarks = "-";
                    }

                    foreach (var renewalLicenseFile in RenewalLicenseFile)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(renewalLicenseFile.FileName);
                        var extension = Path.GetExtension(renewalLicenseFile.FileName);

                        licenseSite.RenewalFileType = renewalLicenseFile.ContentType;
                        licenseSite.RenewalExtension = extension;
                        licenseSite.RenewalLicenseFileName = fileName;

                        using (var dataStream = new MemoryStream())
                        {
                            renewalLicenseFile.CopyToAsync(dataStream);
                            licenseSite.RenewalData = dataStream.ToArray();
                        }
                    }

                    if (RenewalLicenseFile.Count == 0)
                    {
                        licenseSite.RenewalLicenseFileName = "-";
                    }

                    licenseSiteDbContext.RenewalLicenseSite(licenseSite);

                    //ddlCategory
                    List<LicenseSite> categoryLicenseSiteList = dbDDLContext.ddlCategoryLicenseSite().ToList();
                    categoryLicenseSiteList.Insert(0, new LicenseSite { CategoryID = 0, CategoryName = "Please Select Type of License" });
                    ViewBag.ListofCategory = categoryLicenseSiteList;

                    //ddlBusinessDiv
                    List<LicenseSite> businessDivLicenseSiteList = dbDDLContext.ddlBusinessDivLicenseSite().ToList();
                    businessDivLicenseSiteList.Insert(0, new LicenseSite { DivID = 0, DivName = "Please Select Business Division" });
                    ViewBag.ListofBusinessDiv = businessDivLicenseSiteList;

                    //ddlBusinessUnit
                    List<LicenseSite> businessUnitLicenseSiteList = dbDDLContext.ddlBusinessUnitLicenseSite().ToList();
                    businessUnitLicenseSiteList.Insert(0, new LicenseSite { UnitID = 0, UnitName = "Please Select Business Unit" });
                    ViewBag.ListofBusinessUnit = businessUnitLicenseSiteList;

                    //ddlPIC2
                    List<LicenseSite> PIC2LicenseSiteList = dbDDLContext.ddlPIC2LicenseSite().ToList();
                    PIC2LicenseSiteList.Insert(0, new LicenseSite { PIC2StaffNo = "-", PIC2Name = "Please Select PIC 2 Name" });
                    ViewBag.ListofPIC2 = PIC2LicenseSiteList;

                    //ddlPIC3
                    List<LicenseSite> PIC3LicenseSiteList = dbDDLContext.ddlPIC3LicenseSite().ToList();
                    PIC3LicenseSiteList.Insert(0, new LicenseSite { PIC3StaffNo = "-", PIC3Name = "Please Select PIC 3 Name" });
                    ViewBag.ListofPIC3 = PIC3LicenseSiteList;

                    return RedirectToAction("Index");
                }

                return View(licenseSite);
            }
            catch
            {
                return View();
            }
        }
        #endregion

        // GET: LicenseSiteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LicenseSiteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LicenseHQController/Download
        public ActionResult DownloadLicenseFile(int id)
        {
            LicenseSite licenseSite = licenseSiteDbContext.GetLicenseSiteByID(id);

            if (licenseSite == null)
            {
                return NotFound();
            }

            return File(licenseSite.Data, licenseSite.FileType, licenseSite.LicenseFileName + licenseSite.Extension);
        }
    }
}
