using BLMS.v2.Context;
using BLMS.v2.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BLMS.Helper;

namespace BLMS.v2.Controllers
{
    public class AuthorityLinkController : Controller
    {
        readonly BLMSDbContext dbContext = new BLMSDbContext();

        public IActionResult Index()
        {
            List<Authority> authorityList = dbContext.AuthorityGetAll().ToList();

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

            return View(authorityList);
        }

        // GET: AuthorityController/Create
        [NoDirectAccess]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Authority authority)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string AuthorityName = authority.AuthorityName;

                    Authority Checkauthority = dbContext.CheckAuthorityByName(AuthorityName);

                    if (Checkauthority.ExistData == 1)
                    {
                        ViewBag.Message = string.Format("{0} already existed in database!", AuthorityName);
                        return View(authority);
                    }
                    else
                    {
                        dbContext.AddAuthority(authority);
                        TempData["createMessage"] = string.Format("{0} has been successfully created!", AuthorityName);
                        return RedirectToAction("Index");
                    }
                }

                return View(authority);
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessDivController/Edit/5
        [NoDirectAccess]
        public ActionResult Edit(int AuthorityID)
        {
            Authority authority = dbContext.GetAuthorityLinkByID(AuthorityID);

            if (authority == null)
            {
                return NotFound();
            }

            return View(authority);
        }

        // POST: BusinessDivController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind] Authority authority)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string AuthorityName = authority.AuthorityName;

                    Authority Checkauthority = dbContext.CheckAuthorityByName(AuthorityName);

                    if (Checkauthority.ExistData == 1)
                    {
                        TempData["editMessage"] = string.Format("{0} already existed in database!", AuthorityName);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        dbContext.EditAuthorityLink(authority);
                        TempData["editMessage"] = string.Format("{0} has been successfully edited!", AuthorityName);
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

        // POST: AuthorityController/Delete/5
        public ActionResult Delete(int AuthorityID)
        {
            try
            {
                Authority authority = dbContext.GetAuthorityLinkByID(AuthorityID);

                dbContext.DeleteAuthorityLink(AuthorityID);
                TempData["deleteMessage"] = string.Format("{0} has been successfully deleted!", authority.AuthorityName);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
