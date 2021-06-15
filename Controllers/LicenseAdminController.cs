using BLMS.v2.Context;
using BLMS.v2.Models.License;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLMS.v2.Controllers
{
    public class LicenseAdminController : Controller
    {
        readonly LicenseDbContext licenseAdminDbContext = new LicenseDbContext();
        readonly ddlDbContext dbDDLContext = new ddlDbContext();

        // GET: LicenseAdminController
        public ActionResult Index()
        {
            List<LicenseAdmin> licenseAdminList = licenseAdminDbContext.LicenseAdminGetAll().ToList();

            return View(licenseAdminList);
        }

        // GET: LicenseAdminController/RequestDetails/5
        public ActionResult RequestDetails(int id)
        {
            LicenseAdmin licenseAdmin = licenseAdminDbContext.GetLicenseRequestAdminByID(id);

            if (licenseAdmin == null)
            {
                return NotFound();
            }

            return View(licenseAdmin);
        }

        // GET: LicenseAdminController/RegisterDetails/5
        public ActionResult RegisterDetails(int id)
        {
            LicenseAdmin licenseAdmin = licenseAdminDbContext.GetLicenseRegisterAdminByID(id);

            if (licenseAdmin == null)
            {
                return NotFound();
            }

            return View(licenseAdmin);
        }

        // GET: LicenseAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LicenseAdminController/Delete/5
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
    }
}
