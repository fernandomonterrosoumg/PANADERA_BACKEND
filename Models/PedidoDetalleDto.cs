namespace ApiNetCore7.Models
{
    public class PedidoDetalleDto
    {
        public long? PEDIDO_DET_ID { get; set; }
        public long? PEDIDO_ID { get; set; }
        public int? CANTIDAD { get; set; }
        public long? PRODUCTO_ID { get; set; }
    }
}
