namespace ApiNetCore7.Models
{
    public class ProductoDto
    {
        public int? PRODUCTO_ID { get; set; }
        public int RECETA_ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public int SUCURSAL_ID { get; set; }
        public decimal PRECIO { get; set; }
        public string IMAGEN { get; set; }
        public int STOCK_ORIGINAL { get; set; }
        public int STOCK_ACTUAL { get; set; }
    }
}
