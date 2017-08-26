using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core;


namespace DataAcessLayer.Model
{
    [Table("TB_PRODUTO_VENDIDO")]
    public class ProdutoVendido 
    {
        //[DataMember]
        [Key]
        [Column("ID_PRODUTO_VENDIDO")]
        public int IdProduto { get; set; }

        //[DataMember]
        [Required]
        [Column("NM_PRODUTO")]
        //[MinLength(5, ErrorMessage = "O nome do produto precisa ter ao menos cinco caracteres.")]
        //[MaxLength(100, ErrorMessage = "O nome do produto não pode ter mais de cem caracteres.")]
        public string NomeProduto { get; set; }

        //[DataMember]
        [Required]
        [Column("DS_PRODUTO")]
        //[MinLength(2, ErrorMessage = "A descrição do produto é muito curta, escreva no mínimo cinquenta caracteres.")]
        [StringLength(500)]
        public string DescricaoProduto { get; set; }

        //[DataMember]
        [Column("NU_QUANTIDADE_PRODUTO")]
        public int QuantidadeProduto { get; set; }

        //[DataMember]
        [Column("VL_PRECO")]
        public decimal PrecoProduto { get; set; }

        //[DataMember]
        [Column("TP_STATUS")]
        public int StatusProduto { get; set; }

        [Column("ID_VENDA")]
        [ForeignKey("ID_VENDA")]
        public int IdVenda { get; set; }

    }
}
