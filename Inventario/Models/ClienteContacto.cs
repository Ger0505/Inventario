namespace Inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClienteContacto")]
    public partial class ClienteContacto
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCli { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCon { get; set; }

        [StringLength(40)]
        public string Descripcion { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Contacto Contacto { get; set; }
    }
}
