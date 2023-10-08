namespace IPC.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductoCategorias
    {
        public int id { get; set; }

        public int idProducto { get; set; }

        public int idCategoria { get; set; }

        public DateTime fechaCreacion { get; set; }

        public bool activo { get; set; }
    }
}
