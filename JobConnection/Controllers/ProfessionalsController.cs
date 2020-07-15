using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using JobConnection.Models;

namespace JobConnection.Controllers
{
    public class ProfessionalsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Professionals
        public IQueryable<Professional> GetProfessionals()
        {
            return db.Professionals;
        }

        // GET: api/Professionals/5
        [ResponseType(typeof(Professional))]
        public async Task<IHttpActionResult> GetProfessional(int id)
        {
            Professional professional = await db.Professionals.FindAsync(id);
            if (professional == null)
            {
                return NotFound();
            }

            return Ok(professional);
        }

        // PUT: api/Professionals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProfessional(int id, Professional professional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != professional.Id)
            {
                return BadRequest();
            }

            db.Entry(professional).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessionalExists(id))
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

        // POST: api/Professionals
        [ResponseType(typeof(Professional))]
        public async Task<IHttpActionResult> PostProfessional(Professional professional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Professionals.Add(professional);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = professional.Id }, professional);
        }

        // DELETE: api/Professionals/5
        [ResponseType(typeof(Professional))]
        public async Task<IHttpActionResult> DeleteProfessional(int id)
        {
            Professional professional = await db.Professionals.FindAsync(id);
            if (professional == null)
            {
                return NotFound();
            }

            db.Professionals.Remove(professional);
            await db.SaveChangesAsync();

            return Ok(professional);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfessionalExists(int id)
        {
            return db.Professionals.Count(e => e.Id == id) > 0;
        }
    }
}