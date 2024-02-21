namespace EntidadeDao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fornecedor")]
    public partial class Fornecedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fornecedor()
        {
            Produtoes = new HashSet<Produto>();
        }

        [Key]
        public int IdFornecedor { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Tellefone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Morada { get; set; }

        public bool? Activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto> Produtoes { get; set; }
    }
}
