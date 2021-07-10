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
    public class LeaveMstsController : ApiController
    {
        private Collegewebapicontext db = new Collegewebapicontext();

        // GET: api/LeaveMsts
        public IQueryable<LeaveMst> GetLeaveMsts()
        {
            return db.LeaveMsts;
        }

        // GET: api/LeaveMsts/5
        [ResponseType(typeof(LeaveMst))]
        public IHttpActionResult GetLeaveMst(int id)
        {
            LeaveMst leaveMst = db.LeaveMsts.Find(id);
            if (leaveMst == null)
            {
                return NotFound();
            }

            return Ok(leaveMst);
        }

        // PUT: api/LeaveMsts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeaveMst(int id, LeaveMst leaveMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leaveMst.ID)
            {
                return BadRequest();
            }

            db.Entry(leaveMst).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveMstExists(id))
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

        // POST: api/LeaveMsts
        [ResponseType(typeof(LeaveMst))]
        public IHttpActionResult PostLeaveMst(LeaveMst leaveMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LeaveMsts.Add(leaveMst);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = leaveMst.ID }, leaveMst);
        }

        // DELETE: api/LeaveMsts/5
        [ResponseType(typeof(LeaveMst))]
        public IHttpActionResult DeleteLeaveMst(int id)
        {
            LeaveMst leaveMst = db.LeaveMsts.Find(id);
            if (leaveMst == null)
            {
                return NotFound();
            }

            db.LeaveMsts.Remove(leaveMst);
            db.SaveChanges();

            return Ok(leaveMst);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeaveMstExists(int id)
        {
            return db.LeaveMsts.Count(e => e.ID == id) > 0;
        }
    }
}