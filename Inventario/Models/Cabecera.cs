namespace Inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cabecera")]
    public partial class Cabecera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cabecera()
        {
            Detalle = new HashSet<Detalle>();
        }

        [Key]
        public int IdCab { get; set; }

        public int IdMov { get; set; }

        public int IdCli { get; set; }

        public int IdEmp { get; set; }

        public int IdDep { get; set; }

        [Required]
        [StringLength(10)]
        public string Fecha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle> Detalle { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Departamento Departamento { get; set; }

        public virtual Empleado Empleado { get; set; }

        public virtual Movimiento Movimiento { get; set; }
    }
}
