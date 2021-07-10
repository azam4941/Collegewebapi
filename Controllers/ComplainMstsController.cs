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
    public class ComplainMstsController : ApiController
    {
        private Collegewebapicontext db = new Collegewebapicontext();

        // GET: api/ComplainMsts
        public IQueryable<ComplainMst> GetComplainMsts()
        {
            return db.ComplainMsts;
        }

        // GET: api/ComplainMsts/5
        [ResponseType(typeof(ComplainMst))]
        public IHttpActionResult GetComplainMst(string id)
        {
            ComplainMst complainMst = db.ComplainMsts.Find(id);
            if (complainMst == null)
            {
                return NotFound();
            }

            return Ok(complainMst);
        }

        // PUT: api/ComplainMsts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComplainMst(string id, ComplainMst complainMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != complainMst.RoLLNo)
            {
                return BadRequest();
            }

            db.Entry(complainMst).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplainMstExists(id))
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

        // POST: api/ComplainMsts
        [ResponseType(typeof(ComplainMst))]
        public IHttpActionResult PostComplainMst(ComplainMst complainMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ComplainMsts.Add(complainMst);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ComplainMstExists(complainMst.RoLLNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = complainMst.RoLLNo }, complainMst);
        }

        // DELETE: api/ComplainMsts/5
        [ResponseType(typeof(ComplainMst))]
        public IHttpActionResult DeleteComplainMst(string id)
        {
            ComplainMst complainMst = db.ComplainMsts.Find(id);
            if (complainMst == null)
            {
                return NotFound();
            }

            db.ComplainMsts.Remove(complainMst);
            db.SaveChanges();

            return Ok(complainMst);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComplainMstExists(string id)
        {
            return db.ComplainMsts.Count(e => e.RoLLNo == id) > 0;
        }
    }
}