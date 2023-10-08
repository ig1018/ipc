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
    public class ProductoCategoriasController : ApiController
    {
        private Entity db = new Entity();

        // GET: api/ProductoCategorias
        public IQueryable<ProductoCategorias> GetProductoCategorias()
        {
            return db.ProductoCategorias;
        }

        // GET: api/ProductoCategorias/5
        [ResponseType(typeof(ProductoCategorias))]
        public async Task<IHttpActionResult> GetProductoCategorias(int id)
        {
            ProductoCategorias productoCategorias = await db.ProductoCategorias.FindAsync(id);
            if (productoCategorias == null)
            {
                return NotFound();
            }

            return Ok(productoCategorias);
        }

        // PUT: api/ProductoCategorias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductoCategorias(int id, ProductoCategorias productoCategorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productoCategorias.id)
            {
                return BadRequest();
            }

            db.Entry(productoCategorias).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoCategoriasExists(id))
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

        // POST: api/ProductoCategorias
        [ResponseType(typeof(ProductoCategorias))]
        public async Task<IHttpActionResult> PostProductoCategorias(ProductoCategorias productoCategorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductoCategorias.Add(productoCategorias);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productoCategorias.id }, productoCategorias);
        }

        // DELETE: api/ProductoCategorias/5
        [ResponseType(typeof(ProductoCategorias))]
        public async Task<IHttpActionResult> DeleteProductoCategorias(int id)
        {
            ProductoCategorias productoCategorias = await db.ProductoCategorias.FindAsync(id);
            if (productoCategorias == null)
            {
                return NotFound();
            }

            db.ProductoCategorias.Remove(productoCategorias);
            await db.SaveChangesAsync();

            return Ok(productoCategorias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductoCategoriasExists(int id)
        {
            return db.ProductoCategorias.Count(e => e.id == id) > 0;
        }
    }
}