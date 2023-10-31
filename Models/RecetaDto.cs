namespace ApiNetCore7.Models
{
    public class RecetaDto
    {
        public int RECETA_ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public List<RecetaDetalleDto> DetallesReceta { get; set; } 
    }

    public class RecetaDetalleDto
    {
        public int RECETA_DETALLE_ID { get; set; }
        public int RECETA_ID { get; set; }
        public int INGREDIENTE_ID { get; set; }
        public decimal CANTIDAD_NECESARIA { get; set; }
        public int UNIDAD_MEDIDA_ID { get; set; }
    }

}
