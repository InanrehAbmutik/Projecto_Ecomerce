namespace EntidadeDao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DISTRITO")]
    public partial class DISTRITO
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string IdDistrito { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(45)]
        public string Descricao { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string IdProvincia { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2)]
        public string IdDepartamento { get; set; }
    }
}
