namespace ApiNetCore7.Models
{
    public class RutaDto
    {
        public int? RUTA_ID { get; set; }
        public int TRANSPORTE_ID { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal DISTANCIA { get; set; }
        public string TIEMPO_ESTIMADO { get; set; }
        public int SUCURSAL_ID_ORIGEN { get; set; }
        public int SUCURSAL_ID_FIN { get; set; }
        
    }
}
