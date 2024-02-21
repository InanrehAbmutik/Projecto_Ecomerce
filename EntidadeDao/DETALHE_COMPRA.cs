namespace EntidadeDao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALHE_COMPRA
    {
        [Key]
        public int IdDetalheCompra { get; set; }

        public int? IdCompra { get; set; }

        public int? IdProduto { get; set; }

        public int? Qtdade { get; set; }

        public decimal? Total { get; set; }

        public virtual COMPRA COMPRA { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
