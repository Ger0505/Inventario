namespace Inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleado")]
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            Cabecera = new HashSet<Cabecera>();
            EmpleadoContacto = new HashSet<EmpleadoContacto>();
        }

        [Key]
        public int IdEmp { get; set; }

        public int? IdPersona { get; set; }

        [StringLength(40)]
        public string Sueldo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cabecera> Cabecera { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpleadoContacto> EmpleadoContacto { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
