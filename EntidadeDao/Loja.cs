namespace EntidadeDao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loja")]
    public partial class Loja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loja()
        {
            Produtoes = new HashSet<Produto>();
        }

        [Key]
        public int IdLoja { get; set; }

        [StringLength(50)]
        public string Descricao { get; set; }

        public bool? Activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto> Produtoes { get; set; }
    }
}
