using System;
using System.Collections.Generic;

namespace BloxityAppAPI.Models
{
    public partial class Producto
    {
        public long ProductoId { get; set; }
        public long? ProveedorId { get; set; }
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Unidad { get; set; } = null!;
        public decimal Costo { get; set; }
        public string? Estado { get; set; }

        public DateTime? FechaDeCreacion { get; set; }
        public DateTime? FechaDeModificacion { get; set; }
        public DateTime? FechaDeEliminacion { get; set; }

        public virtual Proveedor? Proveedor { get; set; }
    }
}
