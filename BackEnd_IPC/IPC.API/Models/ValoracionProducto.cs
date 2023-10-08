namespace IPC.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ValoracionProducto")]
    public partial class ValoracionProducto
    {
        public int id { get; set; }

        public int idProducto { get; set; }

        public int idUsuario { get; set; }

        public int valoracion { get; set; }

        public DateTime fechaCreacion { get; set; }

        public bool activo { get; set; }

        public virtual Productos Productos { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
