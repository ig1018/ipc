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
    public class TiposPagosController : ApiController
    {
        private Entity db = new Entity();

        // GET: api/TiposPagos
        public IQueryable<TiposPago> GetTiposPago()
        {
            return db.TiposPago;
        }

        // GET: api/TiposPagos/5
        [ResponseType(typeof(TiposPago))]
        public async Task<IHttpActionResult> GetTiposPago(int id)
        {
            TiposPago tiposPago = await db.TiposPago.FindAsync(id);
            if (tiposPago == null)
            {
                return NotFound();
            }

            return Ok(tiposPago);
        }

        // PUT: api/TiposPagos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTiposPago(int id, TiposPago tiposPago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tiposPago.id)
            {
                return BadRequest();
            }

            db.Entry(tiposPago).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposPagoExists(id))
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

        // POST: api/TiposPagos
        [ResponseType(typeof(TiposPago))]
        public async Task<IHttpActionResult> PostTiposPago(TiposPago tiposPago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TiposPago.Add(tiposPago);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tiposPago.id }, tiposPago);
        }

        // DELETE: api/TiposPagos/5
        [ResponseType(typeof(TiposPago))]
        public async Task<IHttpActionResult> DeleteTiposPago(int id)
        {
            TiposPago tiposPago = await db.TiposPago.FindAsync(id);
            if (tiposPago == null)
            {
                return NotFound();
            }

            db.TiposPago.Remove(tiposPago);
            await db.SaveChangesAsync();

            return Ok(tiposPago);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TiposPagoExists(int id)
        {
            return db.TiposPago.Count(e => e.id == id) > 0;
        }
    }
}