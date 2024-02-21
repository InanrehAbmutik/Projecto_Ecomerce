using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTest.Models
{
    public class Encomendas
    {
        public int IdCompra { get; set; }
        public string Nomes { get; set; }
        public string Telefone { get; set; }
        public string Direcao { get; set; }
        public string Total { get; set; }
        public string TotalProduto { get; set; }
        public string DataCompra { get; set; }
    }
}