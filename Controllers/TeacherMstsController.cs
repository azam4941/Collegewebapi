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
    public class TeacherMstsController : ApiController
    {
        private Collegewebapicontext db = new Collegewebapicontext();

        // GET: api/TeacherMsts
        public IQueryable<TeacherMst> GetTeacherMsts()
        {
            return db.TeacherMsts;
        }

        // GET: api/TeacherMsts/5
        [ResponseType(typeof(TeacherMst))]
        public IHttpActionResult GetTeacherMst(int id)
        {
            TeacherMst teacherMst = db.TeacherMsts.Find(id);
            if (teacherMst == null)
            {
                return NotFound();
            }

            return Ok(teacherMst);
        }

        // PUT: api/TeacherMsts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeacherMst(int id, TeacherMst teacherMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacherMst.ID)
            {
                return BadRequest();
            }

            db.Entry(teacherMst).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherMstExists(id))
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

        // POST: api/TeacherMsts
        [ResponseType(typeof(TeacherMst))]
        public IHttpActionResult PostTeacherMst(TeacherMst teacherMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TeacherMsts.Add(teacherMst);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teacherMst.ID }, teacherMst);
        }

        // DELETE: api/TeacherMsts/5
        [ResponseType(typeof(TeacherMst))]
        public IHttpActionResult DeleteTeacherMst(int id)
        {
            TeacherMst teacherMst = db.TeacherMsts.Find(id);
            if (teacherMst == null)
            {
                return NotFound();
            }

            db.TeacherMsts.Remove(teacherMst);
            db.SaveChanges();

            return Ok(teacherMst);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeacherMstExists(int id)
        {
            return db.TeacherMsts.Count(e => e.ID == id) > 0;
        }
    }
}