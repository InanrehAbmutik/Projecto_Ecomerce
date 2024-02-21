namespace EntidadeDao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produto")]
    public partial class Produto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produto()
        {
            CARRITOes = new HashSet<CARRITO>();
            DETALHE_COMPRA = new HashSet<DETALHE_COMPRA>();
        }

        [Key]
        public int IdProduto { get; set; }

        [StringLength(500)]
        public string Nome { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        public int? IdCategoria { get; set; }

        public decimal? Preco { get; set; }

        public int? Stock { get; set; }

        [StringLength(100)]
        public string RotaImagem { get; set; }

        public bool? Activo { get; set; }

        public DateTime? DataRegisto { get; set; }

        public int? IdLoja { get; set; }

        public int? IdFornecedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARRITO> CARRITOes { get; set; }

        public virtual CATEGORIA CATEGORIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALHE_COMPRA> DETALHE_COMPRA { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        public virtual Loja Loja { get; set; }
    }
}
