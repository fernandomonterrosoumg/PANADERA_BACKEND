namespace ApiNetCore7.Models
{
    public class PedidoCompletoDto
    {
        public PedidoDto pedido { get; set; }
        public List<PedidoDetalleDto> detalles { get; set; }
    }
}
