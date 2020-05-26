namespace Inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Direccion")]
    public partial class Direccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direccion()
        {
            Persona = new HashSet<Persona>();
        }

        [Key]
        public int IdDir { get; set; }

        [Required]
        [StringLength(40)]
        public string Pais { get; set; }

        [Required]
        [StringLength(40)]
        public string Estado { get; set; }

        [Required]
        [StringLength(40)]
        public string Ciudad { get; set; }

        [Required]
        [StringLength(40)]
        public string Colonia { get; set; }

        [Required]
        [StringLength(40)]
        public string Calle { get; set; }

        public int NumExt { get; set; }

        public int? NumInt { get; set; }

        public int CodePostal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
