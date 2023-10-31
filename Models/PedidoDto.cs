namespace ApiNetCore7.Models
{
    public class PedidoDto
    {
        public decimal PEDIDO_ID { get; set; }
        public decimal CANTIDAD_SOLICITADA { get; set; }
        public DateTime FECHA_PEDIDO { get; set; }
        public DateTime? FECHA_DESPACHO { get; set; }
        public decimal? USUARIO_ID { get; set; }
        public DateTime? FECHA_INGRESO_REAL { get; set; }
        public decimal RUTA_ID { get; set; }
        public int? STATUS { get; set; }
        public int? MINI_SISTEM_ID { get; set; }
    }
}
