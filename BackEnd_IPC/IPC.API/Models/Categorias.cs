namespace IPC.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Categorias
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public string imagen { get; set; }

        [StringLength(50)]
        public string identificador { get; set; }

        public DateTime fechaCreacion { get; set; }

        public bool activo { get; set; }
    }
}
