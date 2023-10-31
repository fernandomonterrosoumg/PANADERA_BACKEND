namespace ApiNetCore7.Models
{
    public class UsuarioConRolDto
    {
        public int USUARIO_ID { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; } 
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimoIngreso { get; set; }
        public int ROL_TIPO_ID { get; set; }
        public string RolNombre { get; set; }
        public string RolDESCRIPCION { get; set; }
    }
}
