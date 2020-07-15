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
    public class SeekersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Seekers
        public IQueryable<Seeker> GetSeekers()
        {
            return db.Seekers;
        }

        // GET: api/Seekers/5
        [ResponseType(typeof(Seeker))]
        public async Task<IHttpActionResult> GetSeeker(int id)
        {
            Seeker seeker = await db.Seekers.FindAsync(id);
            if (seeker == null)
            {
                return NotFound();
            }

            return Ok(seeker);
        }

        // PUT: api/Seekers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSeeker(int id, Seeker seeker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seeker.Id)
            {
                return BadRequest();
            }

            db.Entry(seeker).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeekerExists(id))
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

        // POST: api/Seekers
        [ResponseType(typeof(Seeker))]
        public async Task<IHttpActionResult> PostSeeker(Seeker seeker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Seekers.Add(seeker);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = seeker.Id }, seeker);
        }

        // DELETE: api/Seekers/5
        [ResponseType(typeof(Seeker))]
        public async Task<IHttpActionResult> DeleteSeeker(int id)
        {
            Seeker seeker = await db.Seekers.FindAsync(id);
            if (seeker == null)
            {
                return NotFound();
            }

            db.Seekers.Remove(seeker);
            await db.SaveChangesAsync();

            return Ok(seeker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeekerExists(int id)
        {
            return db.Seekers.Count(e => e.Id == id) > 0;
        }
    }
}