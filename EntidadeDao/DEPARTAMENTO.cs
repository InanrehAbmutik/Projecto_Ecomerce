namespace EntidadeDao
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPARTAMENTO")]
    public partial class DEPARTAMENTO
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string IdDepartamento { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(45)]
        public string Descricao { get; set; }
    }
}
