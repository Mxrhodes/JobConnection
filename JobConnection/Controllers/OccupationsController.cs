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
    public class OccupationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Occupations
        public IQueryable<Occupation> GetOccupations()
        {
            return db.Occupations;
        }

        // GET: api/Occupations/5
        [ResponseType(typeof(Occupation))]
        public async Task<IHttpActionResult> GetOccupation(int id)
        {
            Occupation occupation = await db.Occupations.FindAsync(id);
            if (occupation == null)
            {
                return NotFound();
            }

            return Ok(occupation);
        }

        // PUT: api/Occupations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOccupation(int id, Occupation occupation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != occupation.Id)
            {
                return BadRequest();
            }

            db.Entry(occupation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OccupationExists(id))
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

        // POST: api/Occupations
        [ResponseType(typeof(Occupation))]
        public async Task<IHttpActionResult> PostOccupation(Occupation occupation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Occupations.Add(occupation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = occupation.Id }, occupation);
        }

        // DELETE: api/Occupations/5
        [ResponseType(typeof(Occupation))]
        public async Task<IHttpActionResult> DeleteOccupation(int id)
        {
            Occupation occupation = await db.Occupations.FindAsync(id);
            if (occupation == null)
            {
                return NotFound();
            }

            db.Occupations.Remove(occupation);
            await db.SaveChangesAsync();

            return Ok(occupation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OccupationExists(int id)
        {
            return db.Occupations.Count(e => e.Id == id) > 0;
        }
    }
}