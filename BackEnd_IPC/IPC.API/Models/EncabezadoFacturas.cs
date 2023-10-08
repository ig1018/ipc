namespace IPC.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EncabezadoFacturas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EncabezadoFacturas()
        {
            DetallesFactura = new HashSet<DetallesFactura>();
        }

        public int id { get; set; }

        public int idUsuario { get; set; }

        public DateTime fechaFactura { get; set; }

        [Column(TypeName = "money")]
        public decimal totalSinImpuesto { get; set; }

        [Column(TypeName = "money")]
        public decimal totalConImpuesto { get; set; }

        [Column(TypeName = "money")]
        public decimal impuesto { get; set; }

        [StringLength(300)]
        public string direccionEnvio { get; set; }

        [StringLength(300)]
        public string direccionFactura { get; set; }

        public int idTipoPago { get; set; }

        public int fechaCreacion { get; set; }

        public bool activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesFactura> DetallesFactura { get; set; }

        public virtual TiposPago TiposPago { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
