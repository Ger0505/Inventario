namespace Inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Detalle")]
    public partial class Detalle
    {
        [Key]
        public int IdDet { get; set; }

        public int IdCab { get; set; }

        public int IdPro { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Cantidad { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Total { get; set; }

        public virtual Cabecera Cabecera { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
