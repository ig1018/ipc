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
    public class ValoracionProductosController : ApiController
    {
        private Entity db = new Entity();

        // GET: api/ValoracionProductoes
        public IQueryable<ValoracionProducto> GetValoracionProducto()
        {
            return db.ValoracionProducto;
        }

        // GET: api/ValoracionProductoes/5
        [ResponseType(typeof(ValoracionProducto))]
        public async Task<IHttpActionResult> GetValoracionProducto(int id)
        {
            ValoracionProducto valoracionProducto = await db.ValoracionProducto.FindAsync(id);
            if (valoracionProducto == null)
            {
                return NotFound();
            }

            return Ok(valoracionProducto);
        }

        // PUT: api/ValoracionProductoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutValoracionProducto(int id, ValoracionProducto valoracionProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != valoracionProducto.id)
            {
                return BadRequest();
            }

            db.Entry(valoracionProducto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValoracionProductoExists(id))
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

        // POST: api/ValoracionProductoes
        [ResponseType(typeof(ValoracionProducto))]
        public async Task<IHttpActionResult> PostValoracionProducto(ValoracionProducto valoracionProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ValoracionProducto.Add(valoracionProducto);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = valoracionProducto.id }, valoracionProducto);
        }

        // DELETE: api/ValoracionProductoes/5
        [ResponseType(typeof(ValoracionProducto))]
        public async Task<IHttpActionResult> DeleteValoracionProducto(int id)
        {
            ValoracionProducto valoracionProducto = await db.ValoracionProducto.FindAsync(id);
            if (valoracionProducto == null)
            {
                return NotFound();
            }

            db.ValoracionProducto.Remove(valoracionProducto);
            await db.SaveChangesAsync();

            return Ok(valoracionProducto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ValoracionProductoExists(int id)
        {
            return db.ValoracionProducto.Count(e => e.id == id) > 0;
        }
    }
}