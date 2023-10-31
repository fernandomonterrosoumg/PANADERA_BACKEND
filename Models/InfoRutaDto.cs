namespace ApiNetCore7.Models
{
    public class InfoRutaDto
    {
        public string nombre_inicio { get; set; }
        public string nombre_fin { get; set; }
        public int ruta_id { get; set; }
        public decimal distancia { get; set; }
        public string descripcion { get; set; }
        public string descripcion_transporte { get; set; }
        public string tipo { get; set; }
        public int sucursal_id_ini { get; set; }
    }
}
