using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRepasoExamenCubos.Models
{
    [Table("COMPRA")]
    public class Compra
    {
        [Key]
        [Column("id_compra")]
        public int IdCompra { get; set; }
        [Column("nombre_cubo")]
        public string NombreCubo { get; set; }
        [Column("precio")]
        public decimal Precio { get; set; }
        [Column("fechapedido")]
        public DateTime FechaPedido { get; set; }
    }
}
