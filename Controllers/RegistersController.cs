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
    public class RegistersController : ApiController
    {
        private Collegewebapicontext db = new Collegewebapicontext();

        // GET: api/Registers
        public IQueryable<Register> GetRegisters()
        {
            return db.Registers;
        }

        // GET: api/Registers/5
        [ResponseType(typeof(Register))]
        public IHttpActionResult GetRegister(int id)
        {
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return NotFound();
            }

            return Ok(register);
        }

        // PUT: api/Registers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegister(int id, Register register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != register.ID)
            {
                return BadRequest();
            }

            db.Entry(register).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(id))
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

        // POST: api/Registers
        [ResponseType(typeof(Register))]
        public IHttpActionResult PostRegister(Register register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Registers.Add(register);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = register.ID }, register);
        }

        // DELETE: api/Registers/5
        [ResponseType(typeof(Register))]
        public IHttpActionResult DeleteRegister(int id)
        {
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return NotFound();
            }

            db.Registers.Remove(register);
            db.SaveChanges();

            return Ok(register);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegisterExists(int id)
        {
            return db.Registers.Count(e => e.ID == id) > 0;
        }
    }
}