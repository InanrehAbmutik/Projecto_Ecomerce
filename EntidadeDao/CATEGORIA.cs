namespace EntidadeDao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATEGORIA")]
    public partial class CATEGORIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIA()
        {
            Produtoes = new HashSet<Produto>();
        }

        [Key]
        public int IdCategoria { get; set; }

        [StringLength(100)]
        public string Descricao { get; set; }

        public bool? Activo { get; set; }

        public DateTime? DataRegisto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto> Produtoes { get; set; }
    }
}
