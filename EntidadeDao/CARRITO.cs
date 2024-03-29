namespace EntidadeDao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CARRITO")]
    public partial class CARRITO
    {
        [Key]
        public int IdCarrito { get; set; }

        public int? IdUsuario { get; set; }

        public int? IdProduto { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
