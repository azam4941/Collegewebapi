using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using collegewebapi.DAL;
using collegewebapi.Models;

namespace collegewebapi.Controllers
{
    public class EventMstsController : ApiController
    {
        private Collegewebapicontext db = new Collegewebapicontext();

        // GET: api/EventMsts
        public IQueryable<EventMst> GetEventMsts()
        {
            return db.EventMsts;
        }

        // GET: api/EventMsts/5
        [ResponseType(typeof(EventMst))]
        public IHttpActionResult GetEventMst(int id)
        {
            EventMst eventMst = db.EventMsts.Find(id);
            if (eventMst == null)
            {
                return NotFound();
            }

            return Ok(eventMst);
        }

        // PUT: api/EventMsts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventMst(int id, EventMst eventMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventMst.NID)
            {
                return BadRequest();
            }

            db.Entry(eventMst).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventMstExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EventMsts
        [ResponseType(typeof(EventMst))]
        public IHttpActionResult PostEventMst(EventMst eventMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventMsts.Add(eventMst);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventMst.NID }, eventMst);
        }

        // DELETE: api/EventMsts/5
        [ResponseType(typeof(EventMst))]
        public IHttpActionResult DeleteEventMst(int id)
        {
            EventMst eventMst = db.EventMsts.Find(id);
            if (eventMst == null)
            {
                return NotFound();
            }

            db.EventMsts.Remove(eventMst);
            db.SaveChanges();

            return Ok(eventMst);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventMstExists(int id)
        {
            return db.EventMsts.Count(e => e.NID == id) > 0;
        }
    }
}