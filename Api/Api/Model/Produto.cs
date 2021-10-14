using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    [Table("TPRODUTO")]
    public class Produto
    {
        [Key]
        public string CODBARRAS { get; set; }

        public string NOMEFANTASIA { get; set; }

        public int CODIGOREDUZIDO { get; set; }

        public Decimal PRECO1 { get; set; }


    }
}
