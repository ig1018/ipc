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
using IPC.API.Models;

namespace IPC.API.Controllers
{
    public class TipoUsuariosController : ApiController
    {
        private Entity db = new Entity();

        // GET: api/TipoUsuarios
        public IQueryable<TipoUsuario> GetTipoUsuario()
        {
            return db.TipoUsuario;
        }

        // GET: api/TipoUsuarios/5
        [ResponseType(typeof(TipoUsuario))]
        public async Task<IHttpActionResult> GetTipoUsuario(int id)
        {
            TipoUsuario tipoUsuario = await db.TipoUsuario.FindAsync(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return Ok(tipoUsuario);
        }

        // PUT: api/TipoUsuarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipoUsuario(int id, TipoUsuario tipoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoUsuario.id)
            {
                return BadRequest();
            }

            db.Entry(tipoUsuario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoUsuarioExists(id))
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

        // POST: api/TipoUsuarios
        [ResponseType(typeof(TipoUsuario))]
        public async Task<IHttpActionResult> PostTipoUsuario(TipoUsuario tipoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoUsuario.Add(tipoUsuario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipoUsuario.id }, tipoUsuario);
        }

        // DELETE: api/TipoUsuarios/5
        [ResponseType(typeof(TipoUsuario))]
        public async Task<IHttpActionResult> DeleteTipoUsuario(int id)
        {
            TipoUsuario tipoUsuario = await db.TipoUsuario.FindAsync(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            db.TipoUsuario.Remove(tipoUsuario);
            await db.SaveChangesAsync();

            return Ok(tipoUsuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoUsuarioExists(int id)
        {
            return db.TipoUsuario.Count(e => e.id == id) > 0;
        }
    }
}