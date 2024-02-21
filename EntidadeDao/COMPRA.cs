namespace EntidadeDao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COMPRA")]
    public partial class COMPRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMPRA()
        {
            DETALHE_COMPRA = new HashSet<DETALHE_COMPRA>();
        }

        [Key]
        public int IdCompra { get; set; }

        public int? IdUsuario { get; set; }

        public int? TotalProduto { get; set; }

        public decimal? Total { get; set; }

        [StringLength(50)]
        public string Contacto { get; set; }

        [StringLength(50)]
        public string Telefone { get; set; }

        [StringLength(500)]
        public string Direcao { get; set; }

        [StringLength(10)]
        public string IdDistrito { get; set; }

        public DateTime? DataCompra { get; set; }

        public virtual USUARIO USUARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALHE_COMPRA> DETALHE_COMPRA { get; set; }
    }
}
