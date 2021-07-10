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
    public class UpgradMstsController : ApiController
    {
        private Collegewebapicontext db = new Collegewebapicontext();

        // GET: api/UpgradMsts
        public IQueryable<UpgradMst> GetUpgradMsts()
        {
            return db.UpgradMsts;
        }

        // GET: api/UpgradMsts/5
        [ResponseType(typeof(UpgradMst))]
        public IHttpActionResult GetUpgradMst(int id)
        {
            UpgradMst upgradMst = db.UpgradMsts.Find(id);
            if (upgradMst == null)
            {
                return NotFound();
            }

            return Ok(upgradMst);
        }

        // PUT: api/UpgradMsts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUpgradMst(int id, UpgradMst upgradMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != upgradMst.SubjectID)
            {
                return BadRequest();
            }

            db.Entry(upgradMst).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UpgradMstExists(id))
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

        // POST: api/UpgradMsts
        [ResponseType(typeof(UpgradMst))]
        public IHttpActionResult PostUpgradMst(UpgradMst upgradMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UpgradMsts.Add(upgradMst);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = upgradMst.SubjectID }, upgradMst);
        }

        // DELETE: api/UpgradMsts/5
        [ResponseType(typeof(UpgradMst))]
        public IHttpActionResult DeleteUpgradMst(int id)
        {
            UpgradMst upgradMst = db.UpgradMsts.Find(id);
            if (upgradMst == null)
            {
                return NotFound();
            }

            db.UpgradMsts.Remove(upgradMst);
            db.SaveChanges();

            return Ok(upgradMst);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UpgradMstExists(int id)
        {
            return db.UpgradMsts.Count(e => e.SubjectID == id) > 0;
        }
    }
}