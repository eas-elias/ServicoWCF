using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Model
{
    //[DataContract]
    [Table("TB_VENDA")]
    public class Venda
    {
        //[DataMember]
        [Key]
        [Column("ID_VENDA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenda { get; set; }

        //[DataMember]
        [Required]
        [Column("DT_VENDA")]
        public DateTime DataVenda { get; set; }

        //[DataMember]
        [Required]
        [Column("VL_VENDA")]
        public decimal valorVenda { get; set; }

        [NotMapped]
        public HashSet<ProdutoVendido> Produtos { get; set; }

    }
}
