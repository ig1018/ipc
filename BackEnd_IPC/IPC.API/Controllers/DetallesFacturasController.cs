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
    public class DetallesFacturasController : ApiController
    {
        private Entity db = new Entity();

        // GET: api/DetallesFacturas
        public IQueryable<DetallesFactura> GetDetallesFactura()
        {
            return db.DetallesFactura;
        }

        // GET: api/DetallesFacturas/5
        [ResponseType(typeof(DetallesFactura))]
        public async Task<IHttpActionResult> GetDetallesFactura(int id)
        {
            DetallesFactura detallesFactura = await db.DetallesFactura.FindAsync(id);
            if (detallesFactura == null)
            {
                return NotFound();
            }

            return Ok(detallesFactura);
        }

        // PUT: api/DetallesFacturas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDetallesFactura(int id, DetallesFactura detallesFactura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detallesFactura.id)
            {
                return BadRequest();
            }

            db.Entry(detallesFactura).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesFacturaExists(id))
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

        // POST: api/DetallesFacturas
        [ResponseType(typeof(DetallesFactura))]
        public async Task<IHttpActionResult> PostDetallesFactura(DetallesFactura detallesFactura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetallesFactura.Add(detallesFactura);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = detallesFactura.id }, detallesFactura);
        }

        // DELETE: api/DetallesFacturas/5
        [ResponseType(typeof(DetallesFactura))]
        public async Task<IHttpActionResult> DeleteDetallesFactura(int id)
        {
            DetallesFactura detallesFactura = await db.DetallesFactura.FindAsync(id);
            if (detallesFactura == null)
            {
                return NotFound();
            }

            db.DetallesFactura.Remove(detallesFactura);
            await db.SaveChangesAsync();

            return Ok(detallesFactura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetallesFacturaExists(int id)
        {
            return db.DetallesFactura.Count(e => e.id == id) > 0;
        }
    }
}