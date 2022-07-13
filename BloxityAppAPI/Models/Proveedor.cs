using System;
using System.Collections.Generic;

namespace BloxityAppAPI.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public long ProveedorId { get; set; }
        public string Codigo { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string Rfc { get; set; } = null!;
        public string? Estado { get; set; }
        public DateTime? FechaDeCreacion { get; set; }
        public DateTime? FechaDeModificacion { get; set; }
        public DateTime? FechaDeEliminacion { get; set; }

        public virtual ICollection<Producto>? Productos { get; set; }
    }
}
