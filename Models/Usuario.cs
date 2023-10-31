namespace ApiNetCore7.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public int RolTipoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimoIngreso { get; set; }
        public RolTipo RolTipo { get; set; }
    }

    public class RolTipo
    {
        public int RolTipoId { get; set; }
        public string Nombre { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
