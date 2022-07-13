using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloxityAppAPI.Models;

namespace BloxityAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly EjercicioBloxityContext _context;

        public ProveedoresController(EjercicioBloxityContext context)
        {
            _context = context;
        }

        // GET: api/Proveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedores()
        {
          if (_context.Proveedores == null)
          {
              return NotFound();
          }
            return await _context.Proveedores.Where(x=> x.Estado=="Creado").ToListAsync();
        }

        [HttpGet("/api/Proveedores/ProveedoresEliminados")]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedoresEliminados()
        {
            if (_context.Proveedores == null)
            {
                return NotFound();
            }
            return await _context.Proveedores.Where(x => x.Estado == "Eliminado").ToListAsync();
        }


        // GET: api/Proveedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetProveedor(long id)
        {
          if (_context.Proveedores == null)
          {
              return NotFound();
          }
            var proveedor = await _context.Proveedores.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }

        // PUT: api/Proveedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
       

        // POST: api/Proveedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        {
          if (_context.Proveedores == null)
          {
              return Problem("Entity set 'EjercicioBloxityContext.Proveedores'  is null.");
          }
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProveedor", new { id = proveedor.ProveedorId }, proveedor);
        }

       
        [HttpPost("/api/Proveedores/EditarProveedor/{id}")]
        public async Task<IActionResult> PutProveedor(long id, Proveedor proveedorDTO)
        {
            if (id != proveedorDTO.ProveedorId)
            {
                return BadRequest();
            }


            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            proveedor.Codigo = proveedorDTO.Codigo;

            proveedor.RazonSocial = proveedorDTO.RazonSocial;

            proveedor.Rfc = proveedorDTO.Rfc;

            proveedor.FechaDeModificacion = proveedorDTO.FechaDeModificacion;


            // _context.Entry(proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("/api/Proveedores/BorrarProveedor/{id}")]
        public async Task<IActionResult> DeleteProveedor(long id, Proveedor proveedor)
        {            
            var proveedor1 = await _context.Proveedores.FindAsync(id);
            if (proveedor1 == null)
            {
                return NotFound();
            }         

            proveedor1.Estado = proveedor.Estado;
            proveedor1.FechaDeEliminacion = proveedor.FechaDeEliminacion;

            //  _context.Remove(i);
            // _context.Entry(proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost("/api/Proveedores/BorrarProveedores/{id}")]
        public async Task<IActionResult> DeleteProveedores(long id)
        {
            var proveedor1 = await _context.Proveedores.FindAsync(id);
            if (proveedor1 == null)
            {
                return NotFound();
            }

            if (ProveedorExist(id))
            {
                var i = _context.Proveedores.Where(e => e.ProveedorId==id).Include(e => e.Productos).First();
                _context.Proveedores.Remove(i);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }               
            }           
            return NoContent();
        }
        private bool ProveedorExists(long id)
        {
            return (_context.Proveedores?.Any(e => e.ProveedorId == id)).GetValueOrDefault();
        }


        [HttpPost("/api/Proveedores/Contiene/{id}")]
        public bool ProveedorExist(long id)
        {
            return (_context.Productos?.Any(e => e.ProveedorId == id)).GetValueOrDefault();
            

        }
    }
}
