namespace Inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmpleadoContacto")]
    public partial class EmpleadoContacto
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdEmp { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCon { get; set; }

        [Required]
        [StringLength(40)]
        public string Descripcion { get; set; }

        public virtual Contacto Contacto { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
