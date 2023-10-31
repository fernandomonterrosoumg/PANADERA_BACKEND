using ApiNetCore7.Handler;
using ApiNetCore7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiNetCore7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly UsuarioHandler _UsuarioHandler;
        public UsuariosController(UsuarioHandler usuarioHandler)
        {
            _UsuarioHandler = usuarioHandler;
        }

        
        [HttpGet("getUsuarios")]
        [Authorize]
        public async Task<RespuestaHttp> Get()
        {
            return await _UsuarioHandler.GetUsuarioConRol();
        }

        [HttpPost("login")]
        public async Task<ActionResult<RespuestaHttp>> LoginYGenerarToken(LoginDto loginDto)
        {
            return await _UsuarioHandler.LoginYGenerarToken(loginDto.usuario, loginDto.contrasena);
            
        }
    }
}
