using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using IPC.API.Models;

namespace IPC.API.Controllers
{
    public class EncabezadoFacturasController : ApiController
    {
        private Entity db = new Entity();

        // GET: api/EncabezadoFacturas
        public IQueryable<EncabezadoFacturas> GetEncabezadoFacturas()
        {
            return db.EncabezadoFacturas;
        }

        // GET: api/EncabezadoFacturas/5
        [ResponseType(typeof(EncabezadoFacturas))]
        public async Task<IHttpActionResult> GetEncabezadoFacturas(int id)
        {
            EncabezadoFacturas encabezadoFacturas = await db.EncabezadoFacturas.FindAsync(id);
            if (encabezadoFacturas == null)
            {
                return NotFound();
            }

            return Ok(encabezadoFacturas);
        }

        // PUT: api/EncabezadoFacturas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEncabezadoFacturas(int id, EncabezadoFacturas encabezadoFacturas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != encabezadoFacturas.id)
            {
                return BadRequest();
            }

            db.Entry(encabezadoFacturas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncabezadoFacturasExists(id))
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

        // POST: api/EncabezadoFacturas
        [ResponseType(typeof(EncabezadoFacturas))]
        public async Task<IHttpActionResult> PostEncabezadoFacturas(EncabezadoFacturas encabezadoFacturas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EncabezadoFacturas.Add(encabezadoFacturas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = encabezadoFacturas.id }, encabezadoFacturas);
        }

        // DELETE: api/EncabezadoFacturas/5
        [ResponseType(typeof(EncabezadoFacturas))]
        public async Task<IHttpActionResult> DeleteEncabezadoFacturas(int id)
        {
            EncabezadoFacturas encabezadoFacturas = await db.EncabezadoFacturas.FindAsync(id);
            if (encabezadoFacturas == null)
            {
                return NotFound();
            }

            db.EncabezadoFacturas.Remove(encabezadoFacturas);
            await db.SaveChangesAsync();

            return Ok(encabezadoFacturas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EncabezadoFacturasExists(int id)
        {
            return db.EncabezadoFacturas.Count(e => e.id == id) > 0;
        }
    }
}