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
    [Route("api/[controller]")]
    [ApiController]
    public class GuestbooksController : ControllerBase
    {
        private IGuestbookManagement mGuestbookManagement;

        public GuestbooksController(IGuestbookManagement guestbookManagement)
        {
            mGuestbookManagement = guestbookManagement;
        }
        // GET: api/Guestbooks
        [HttpGet]
        public ActionResult<IEnumerable<GuestbookDto>> Get()
        {
            var theGuestbooks = mGuestbookManagement.ListAll();
            return theGuestbooks.ToList();
        }

        // GET: api/Guestbooks/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Guestbooks
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Guestbooks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GuestbookDto theDto)
        {
            int a = 10;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
