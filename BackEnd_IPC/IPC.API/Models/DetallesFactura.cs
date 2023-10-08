namespace IPC.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetallesFactura")]
    public partial class DetallesFactura
    {
        public int id { get; set; }

        public int idEncabezadoFactura { get; set; }

        public int idProducto { get; set; }

        [Column(TypeName = "money")]
        public decimal valorUnitarioProducto { get; set; }

        public int cantidadProductos { get; set; }

        [Column(TypeName = "money")]
        public decimal valorTotalProductos { get; set; }

        public DateTime fechaCreacion { get; set; }

        public bool activo { get; set; }

        public virtual EncabezadoFacturas EncabezadoFacturas { get; set; }

        public virtual Productos Productos { get; set; }
    }
}
