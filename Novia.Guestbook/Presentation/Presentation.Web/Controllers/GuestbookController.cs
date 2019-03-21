using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Novia.Guestbook.Application.Abstractions;
using Novia.Guestbook.Application.Abstractions.Dtos;

namespace Novia.Guestbook.Presentation.Web.Controllers
{

    public class GuestbookController : Controller
    {
        private IGuestbookManagement mGuestbookManagement;

        public GuestbookController(IGuestbookManagement guestbookManagement)
        {
            mGuestbookManagement = guestbookManagement;

        }
        // GET: Guestbook
        public IActionResult Index()
        {
            var theGuestbooks = mGuestbookManagement.ListAll();

            return View(theGuestbooks);
        }

        // GET: Guestbook/Details/5
        public ActionResult Details(int id)
        {
            return View(mGuestbookManagement.FindById(id));
        }

        // GET: Guestbook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guestbook/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GuestbookDto newGuestbookDto)
        {
            try
            {
                // TODO: Add insert logic here
                mGuestbookManagement.Add(newGuestbookDto.Name);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Guestbook/Edit/5
        public ActionResult Edit(int id)
        {
            GuestbookDto theBookDto = mGuestbookManagement.FindById(id);
            return View(theBookDto);
        }

        // POST: Guestbook/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GuestbookDto theBookToEditDto)
        {
            try
            {
                mGuestbookManagement.Modify(theBookToEditDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Guestbook/Delete/5
        public ActionResult Delete(int id)
        {
            GuestbookDto theBookDto = mGuestbookManagement.FindById(id);
            return View(theBookDto);
        }

        // POST: Guestbook/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GuestbookDto theBookToDeleteDto)
        {
            try
            {
                mGuestbookManagement.Remove(theBookToDeleteDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}