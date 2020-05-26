namespace Inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            Detalle = new HashSet<Detalle>();
        }

        [Key]
        public int IdPro { get; set; }

        public int? IdProv { get; set; }

        [StringLength(40)]
        public string Nombre { get; set; }

        [StringLength(40)]
        public string CostoUnitario { get; set; }

        [StringLength(40)]
        public string Unidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle> Detalle { get; set; }

        public virtual Proveedor Proveedor { get; set; }
    }
}
