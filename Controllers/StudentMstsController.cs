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
    public class StudentMstsController : ApiController
    {
        private Collegewebapicontext db = new Collegewebapicontext();

        // GET: api/StudentMsts
        public IQueryable<StudentMst> GetStudentMsts()
        {
            return db.StudentMsts;
        }

        // GET: api/StudentMsts/5
        [ResponseType(typeof(StudentMst))]
        public IHttpActionResult GetStudentMst(int id)
        {
            StudentMst studentMst = db.StudentMsts.Find(id);
            if (studentMst == null)
            {
                return NotFound();
            }

            return Ok(studentMst);
        }

        // PUT: api/StudentMsts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentMst(int id, StudentMst studentMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentMst.ID)
            {
                return BadRequest();
            }

            db.Entry(studentMst).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentMstExists(id))
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

        // POST: api/StudentMsts
        [ResponseType(typeof(StudentMst))]
        public IHttpActionResult PostStudentMst(StudentMst studentMst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentMsts.Add(studentMst);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = studentMst.ID }, studentMst);
        }

        // DELETE: api/StudentMsts/5
        [ResponseType(typeof(StudentMst))]
        public IHttpActionResult DeleteStudentMst(int id)
        {
            StudentMst studentMst = db.StudentMsts.Find(id);
            if (studentMst == null)
            {
                return NotFound();
            }

            db.StudentMsts.Remove(studentMst);
            db.SaveChanges();

            return Ok(studentMst);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentMstExists(int id)
        {
            return db.StudentMsts.Count(e => e.ID == id) > 0;
        }
    }
}