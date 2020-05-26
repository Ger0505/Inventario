namespace Inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Cabecera = new HashSet<Cabecera>();
            ClienteContacto = new HashSet<ClienteContacto>();
        }

        [Key]
        public int IdCli { get; set; }

        public int IdPersona { get; set; }

        [Required]
        [StringLength(1)]
        public string Tipo { get; set; }

        [StringLength(50)]
        public string Empresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cabecera> Cabecera { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClienteContacto> ClienteContacto { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
