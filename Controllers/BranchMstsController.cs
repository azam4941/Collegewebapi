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
    public class BranchMstsController : ApiController
    {
        private Collegewebapicontext db = new Collegewebapicontext();

        // GET: api/BranchMsts
        public IQueryable<BranchMst> GetBranchMsts()
        {
            return db.BranchMsts;
        }

        // GET: api/BranchMsts/5
        [ResponseType(typeof(BranchMst))]
        public IHttpActionResult GetBranchMst(int id)
        {
            BranchMst branchMst = db.BranchMsts.Find(id);
            if (branchMst == null)
            {
                return NotFound();
            }

            return Ok(branchMst);
        }

        // PUT: api/BranchMsts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBranchMst(int id, BranchMst branchMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != branchMst.ID)
            {
                return BadRequest();
            }

            db.Entry(branchMst).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchMstExists(id))
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

        // POST: api/BranchMsts
        [ResponseType(typeof(BranchMst))]
        public IHttpActionResult PostBranchMst(BranchMst branchMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BranchMsts.Add(branchMst);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = branchMst.ID }, branchMst);
        }

        // DELETE: api/BranchMsts/5
        [ResponseType(typeof(BranchMst))]
        public IHttpActionResult DeleteBranchMst(int id)
        {
            BranchMst branchMst = db.BranchMsts.Find(id);
            if (branchMst == null)
            {
                return NotFound();
            }

            db.BranchMsts.Remove(branchMst);
            db.SaveChanges();

            return Ok(branchMst);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BranchMstExists(int id)
        {
            return db.BranchMsts.Count(e => e.ID == id) > 0;
        }
    }
}