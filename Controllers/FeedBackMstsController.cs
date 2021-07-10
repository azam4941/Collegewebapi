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
    public class FeedBackMstsController : ApiController
    {
        private Collegewebapicontext db = new Collegewebapicontext();

        // GET: api/FeedBackMsts
        public IQueryable<FeedBackMst> GetFeedBackMsts()
        {
            return db.FeedBackMsts;
        }

        // GET: api/FeedBackMsts/5
        [ResponseType(typeof(FeedBackMst))]
        public IHttpActionResult GetFeedBackMst(int id)
        {
            FeedBackMst feedBackMst = db.FeedBackMsts.Find(id);
            if (feedBackMst == null)
            {
                return NotFound();
            }

            return Ok(feedBackMst);
        }

        // PUT: api/FeedBackMsts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeedBackMst(int id, FeedBackMst feedBackMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedBackMst.ID)
            {
                return BadRequest();
            }

            db.Entry(feedBackMst).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedBackMstExists(id))
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

        // POST: api/FeedBackMsts
        [ResponseType(typeof(FeedBackMst))]
        public IHttpActionResult PostFeedBackMst(FeedBackMst feedBackMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FeedBackMsts.Add(feedBackMst);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = feedBackMst.ID }, feedBackMst);
        }

        // DELETE: api/FeedBackMsts/5
        [ResponseType(typeof(FeedBackMst))]
        public IHttpActionResult DeleteFeedBackMst(int id)
        {
            FeedBackMst feedBackMst = db.FeedBackMsts.Find(id);
            if (feedBackMst == null)
            {
                return NotFound();
            }

            db.FeedBackMsts.Remove(feedBackMst);
            db.SaveChanges();

            return Ok(feedBackMst);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedBackMstExists(int id)
        {
            return db.FeedBackMsts.Count(e => e.ID == id) > 0;
        }
    }
}